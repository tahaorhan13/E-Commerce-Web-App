using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product.Kolye;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolyeController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rKolye Add(pKolye args)
        {
            var productB = new bKolye();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListKolye List(pListKolye args)
        {
            var menuB = new bKolye();

            return menuB.List(args);
        }
    }
}
