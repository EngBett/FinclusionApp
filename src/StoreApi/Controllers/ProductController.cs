using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Data.Entities;

namespace StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private static readonly Product[] Products = new[]
        {
            new Product
            {
                Id = 1,
                Name = "Iphone 13",
                Description = "Iphone 13 pro max lorem ipsum",
                Thumbnail =
                    "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MM1H3_AV1?wid=2000&hei=2000&fmt=jpeg&qlt=80&.v=1629962559000",
                Price = 14999
            },
            new Product
            {
                Id = 2,
                Name = "Projector",
                Description = "Smart projector lorem ipsum",
                Thumbnail =
                    "https://p7.hiclipart.com/preview/973/484/893/multimedia-projectors-home-theater-systems-light-emitting-diode-overhead-projectors-projector-thumbnail.jpg",
                Price = 9999
            },
            new Product
            {
                Id = 3,
                Name = "Lenovo x1 Carbon",
                Description = "Lenovo x1 carbon lorem ipsum",
                Thumbnail =
                    "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSB4ex-XBohG4o8eg1Y26e5beaaH94D8BmK5tEA3n80EMvuu1hJRXMuqr3iWxMrgYAoq-hphYOgLg&usqp=CAc",
                Price = 6500
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(Products);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return Ok(product);
        }
    }
}