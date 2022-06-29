using Beu.Eticaret.Entity.System;
using Eltemtek.Etcs.Bll.System;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpPost]
        [Route("Get")]
        public rRole Get(pRole args)
        {
            var roleB = new bRole();

            return roleB.Get(args);
        }
        [HttpPost]
        [Route("Add")]
        public rRole Add(pRole args)
        {
            var roleB = new bRole();

            return roleB.Add(args);
        }
        [HttpPost]
        [Route("Update")]
        public rRole Update(pRole args)
        {
            var roleB = new bRole();

            return roleB.Update(args);
        }
        [HttpPost]
        [Route("Save")]
        public rRole Save(pRole args)
        {
            var roleB = new bRole();

            return roleB.Save(args);
        }
        //[HttpPost]
        //[Route("Delete")]
        //public rCore Delete(pId args)
        //{
        //    var roleB = new bRole();

        //    return roleB.Delete(args);
        //}
    }
}
