using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product.Yuzuk;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YuzukController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rYuzuk Add(pYuzuk args)
        {
            var productB = new bYuzuk();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListYuzuk List(pListYuzuk args)
        {
            var menuB = new bYuzuk();

            return menuB.List(args);
        }
    }
}
