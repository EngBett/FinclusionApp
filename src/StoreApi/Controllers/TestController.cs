using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public TestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //retrieve access token
            var serverClient = _clientFactory.CreateClient();
            var discoveryDoc = await serverClient.GetDiscoveryDocumentAsync("http://localhost:5000/");
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