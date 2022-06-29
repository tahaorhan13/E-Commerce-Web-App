using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rProduct Add(pProduct args)
        {
            var productB = new bProduct();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListProduct List(pListProduct args)
        {
            var menuB = new bProduct();

            return menuB.List(args);
        }
    }
}
