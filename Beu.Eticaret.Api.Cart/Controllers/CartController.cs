using Beu.Eticaret.Bll.Cart;
using Beu.Eticaret.Entity.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rCart Add(pCart args)
        {
            var cartB = new bCart();

            return cartB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListCart List(pListCart args)
        {
            var cartB = new bCart();

            return cartB.List(args);
        }
        [HttpPost]
        [Route("Delete")]
        public rCart Delete(pCart args)
        {
            var cartB = new bCart();

            return cartB.Delete(args);
        }
    }
}
