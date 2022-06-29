using Beu.Eticaret.Bll.System;
using Beu.Eticaret.Entity.System.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpPost]
        [Route("List")]
        public rListMenu List(pListMenu args)
        {
            var menuB = new bMenu();

            return menuB.List(args);
        }
    }
}
