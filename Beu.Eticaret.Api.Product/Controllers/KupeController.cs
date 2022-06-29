using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product.Kupe;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupeController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rKupe Add(pKupe args)
        {
            var productB = new bKupe();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListKupe List(pListKupe args)
        {
            var menuB = new bKupe();

            return menuB.List(args);
        }
    }
}
