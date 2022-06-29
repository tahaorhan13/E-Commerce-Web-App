using Beu.Eticaret.Bll.Product;
using Beu.Eticaret.Entity.Product.Tesbih;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesbihController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rTesbih Add(pTesbih args)
        {
            var productB = new bTesbih();

            return productB.Add(args);
        }
        [HttpPost]
        [Route("List")]
        public rListTesbih List(pListTesbih args)
        {
            var menuB = new bTesbih();

            return menuB.List(args);
        }
    }
}
