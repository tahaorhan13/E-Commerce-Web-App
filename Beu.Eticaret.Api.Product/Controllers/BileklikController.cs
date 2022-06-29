using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product.Bileklik;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BileklikController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rBileklik Add(pBileklik args)
        {
            var productB = new bBileklik();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListBileklik List(pListBileklik args)
        {
            var menuB = new bBileklik();

            return menuB.List(args);
        }
    }
}
