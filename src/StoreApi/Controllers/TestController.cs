using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public TestController(IHttpClientFactory clientFactory,IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
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
            {
                return BadRequest(new { Message = "Authentication failed" });
            }

            return Ok(tokenResponse.AccessToken);
        }
    }
}