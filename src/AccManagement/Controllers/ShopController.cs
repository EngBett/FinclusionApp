using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AccManagement.Data.Entities;
using AccManagement.Data.Repositories.IRepositories;
using AccManagement.Helpers;
using AccManagement.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AccManagement.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IAccountRepository _accountRepo;
        private readonly IConfiguration _config;
        private Account UserAccount { get; set; }

        public ShopController(IHttpClientFactory clientFactory, IAccountRepository accountRepo,IHttpContextAccessor httpContextAccessor,IConfiguration config)
        {
            _clientFactory = clientFactory;
            _accountRepo = accountRepo;
            _config = config;

            if (httpContextAccessor.HttpContext.User.IsInRole("SuperAdmin")) return;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            UserAccount = _GetAccount(userId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //retrieve access token
            var serverClient = _clientFactory.CreateClient();
            var discoveryDoc = await serverClient.GetDiscoveryDocumentAsync($"{_config.GetSection("IdentityServer").Value}/");
            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDoc.TokenEndpoint,
                ClientId = "StoreApiId",
                ClientSecret = "StoreApiSecret",
                Scope = "StoreApi"
            });

            if (tokenResponse.IsError)
                return RedirectToAction("Index", "Account", new { Error = "Authentication Failed" });

            //retrieve secret data
            var apiClient = _clientFactory.CreateClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var res = await apiClient.GetAsync($"{_config.GetSection("StoreApi").Value}/api/products");

            if (!res.IsSuccessStatusCode)
                return RedirectToAction("Index", "Account", new { error = "Shop threw a bad request" });

            var content = await res.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(content, options);

            return View(products);
        }

        [Authorize(Roles = "BasicUser")]
        [HttpGet]
        public async Task<IActionResult> Cart(int id)
        {
            if (!UserAccount.Active) return Forbid();
            
            //retrieve access token
            var serverClient = _clientFactory.CreateClient();
            var discoveryDoc = await serverClient.GetDiscoveryDocumentAsync($"{_config.GetSection("IdentityServer").Value}/");
            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDoc.TokenEndpoint,
                ClientId = "StoreApiId",
                ClientSecret = "StoreApiSecret",
                Scope = "StoreApi"
            });

            //retrieve secret data
            var apiClient = _clientFactory.CreateClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var res = await apiClient.GetAsync($"{_config.GetSection("StoreApi").Value}/api/products/{id}");
            var content = await res.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var product = JsonSerializer.Deserialize<ProductViewModel>(content, options);

            var cart = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cart))
            {
                product.Qty = 1;
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(new List<ProductViewModel> { product }));
            }
            else
            {
                var products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(cart)?.ToList();
                var inCart = false;
                foreach (var item in products?.Where(item => item.Id == product.Id))
                {
                    item.Qty += 1;
                    inCart = true;
                    break;
                }

                if (!inCart)
                {
                    product.Qty = 1;
                    products?.Add(product);
                }

                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(products));
            }


            return RedirectToAction("Index");
        }

        [Authorize(Roles = "BasicUser")]
        [HttpGet]
        public IActionResult Checkout()
        {
            if (!UserAccount.Active) return Forbid();
            return View();
        }

        [Authorize(Roles = "BasicUser")]
        [HttpPost]
        public async Task<IActionResult> Checkout(object obj)
        {
            if (!UserAccount.Active) return Forbid();
            
            var cart = HttpContext.Session.GetString("Cart");
            var products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(cart)?.ToList();
            var description = string.Join(", ", products.Select(c => c.ToString()));

            //Get Current user
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var account = await _accountRepo.GetAccountByUserIdAsync(userId);

            var newAcc = AccountHelpers.Deduct(account, products.Sum(c => c.Qty * c.Price));
            var transaction = new AccountTransaction
            {
                AccountId = account.Id,
                Description = description,
                Amount = products.Sum(c => c.Qty * c.Price),
                TranStatus = AccountTransaction.TransactionStatus.Completed,
                TranType = AccountTransaction.TransactionType.Deposit,
                CompletedAt = DateTime.Now
            };

            try
            {
                var res = await _accountRepo.UpdateAccountAsync(newAcc, account.Id, transaction);
                if (res != null)
                {
                    HttpContext.Session.Remove("Cart");
                    return RedirectToAction("Index", "Account", new { success = "Products purchased successfully" });
                }

                ModelState.AddModelError("500", "something went wrong");
            }
            catch (Exception)
            {
                ModelState.AddModelError("500", "something went wrong");
            }

            return View();
        }
        
        private Account _GetAccount(string userId)
        {
            var acc = _accountRepo.GetAccountByUserIdAsync(userId).GetAwaiter().GetResult();
            return acc ?? userId.CreateAccount(_accountRepo).GetAwaiter().GetResult();
        }
    }
}