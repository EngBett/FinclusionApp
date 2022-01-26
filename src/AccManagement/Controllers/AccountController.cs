using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AccManagement.Data.Entities;
using AccManagement.Data.Repositories.IRepositories;
using AccManagement.Helpers;
using AccManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IAccountTransactionRepository _transactionRepo;
        private Account UserAccount { get; set; }

        public AccountController(IAccountRepository accountRepo, IAccountTransactionRepository transactionRepo,
            IHttpContextAccessor httpContextAccessor)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
            if (httpContextAccessor.HttpContext.User.IsInRole("SuperAdmin")) return;
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UserAccount = _GetAccount(userId);
        }

        [Authorize(Roles = "BasicUser")]
        public async Task<IActionResult> Index(string success = null, string error = null)
        {
            ViewData["Success"] = success;
            ViewData["Error"] = error;
            ViewBag.Transactions = await _transactionRepo.GetTopTransactionsAsync(10, UserAccount.Id);
            return View(UserAccount);
        }

        [Authorize(Roles = "BasicUser")]
        [HttpGet]
        public IActionResult Deposit()
        {
            if (!UserAccount.Active) return Forbid();
            return View();
        }

        [Authorize(Roles = "BasicUser")]
        [HttpPost]
        public async Task<IActionResult> Deposit(DepositViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            //Get Current user
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //var account = await _accountRepo.GetAccountByUserIdAsync(userId);
            var account = UserAccount;

            if (!account.Active) return Forbid();

            var newAcc = AccountHelpers.Deposit(account, model.Amount);
            var transaction = new AccountTransaction
            {
                AccountId = account.Id,
                Description = model.Narration ?? "Cash deposit",
                Amount = model.Amount,
                TranStatus = AccountTransaction.TransactionStatus.Completed,
                TranType = AccountTransaction.TransactionType.Deposit,
                CompletedAt = DateTime.Now
            };

            try
            {
                var res = await _accountRepo.UpdateAccountAsync(newAcc, account.Id, transaction);
                if (res != null) return RedirectToAction("Index", new { success = "Deposited successfully" });

                ModelState.AddModelError("500", "something went wrong");
            }
            catch (Exception)
            {
                ModelState.AddModelError("500", "something went wrong");
            }

            return View(model);
        }

        [Authorize(Roles = "BasicUser")]
        [HttpGet]
        public IActionResult Withdraw()
        {
            if (!UserAccount.Active) return Forbid();
            return View(new WithdrawalViewModel());
        }

        [Authorize(Roles = "BasicUser")]
        [HttpPost]
        public async Task<IActionResult> Withdraw(WithdrawalViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            //Get Current user
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //var account = await _accountRepo.GetAccountByUserIdAsync(userId);
            var account = UserAccount;
            
            if (!account.Active) return Forbid();
            if (account.Balance < model.Amount)
            {
                ModelState.AddModelError("Amount", "Insufficient balance");
                return View(model);
            }

            var newAcc = AccountHelpers.Withdraw(account, model.Amount);
            var transaction = new AccountTransaction
            {
                AccountId = account.Id,
                Description = model.Narration ?? "Cash withdrawal",
                Amount = model.Amount,
                TranStatus = AccountTransaction.TransactionStatus.Completed,
                TranType = AccountTransaction.TransactionType.Withdrawal,
                CompletedAt = DateTime.Now
            };

            try
            {
                var res = await _accountRepo.UpdateAccountAsync(newAcc, account.Id, transaction);
                if (res != null) return RedirectToAction("Index", new { success = "Withdrawn successfully" });

                ModelState.AddModelError("500", "something went wrong");
            }
            catch (Exception)
            {
                ModelState.AddModelError("500", "something went wrong");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> All(string success = null, string error = null)
        {
            ViewData["Success"] = success;
            ViewData["Error"] = error;

            var accounts = await _accountRepo.GetAccountsAsync();
            return View(accounts);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Show(string id, string success = null, string error = null)
        {
            ViewData["Success"] = success;
            ViewData["Error"] = error;

            var account = await _accountRepo.GetAccountAsync(id);
            ViewBag.Transactions = await _transactionRepo.GetTopTransactionsAsync(10, id);
            return View(account);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Deactivate(string id)
        {
            var account = await _accountRepo.GetAccountAsync(id);
            if (!account.Active) return RedirectToAction("All", new { error = "Account already inactive" });
            account.Active = false;

            await _accountRepo.UpdateAccountAsync(account, account.Id);
            return RedirectToAction("All", new { success = "Deactivated successfully" });
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Activate(string id)
        {
            var account = await _accountRepo.GetAccountAsync(id);
            if (account.Active) return RedirectToAction("All", new { error = "Account already active" });
            account.Active = true;

            await _accountRepo.UpdateAccountAsync(account, account.Id);
            return RedirectToAction("All", new { success = "Activated successfully" });
        }

        private Account _GetAccount(string userId)
        {
            var acc = _accountRepo.GetAccountByUserIdAsync(userId).GetAwaiter().GetResult();
            return acc ?? userId.CreateAccount(_accountRepo).GetAwaiter().GetResult();
        }
    }
}