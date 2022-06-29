using Beu.Eticaret.Bll.Account;
using Beu.Eticaret.Entity.Account;
using Beu.Eticaret.Entity.Account.User;
using Microsoft.AspNetCore.Mvc;

namespace Beu.Eticaret.Api.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public rUser Add(pUser args)
        {
            var userB = new bUser();

            return userB.Add(args);
        }
        [HttpPost]
        [Route("Update")]
        public rUser Update(puUser args)
        {
            var userB = new bUser();

            return userB.Update(args);
        }
        [HttpPost]
        [Route("List")]
        public rListUser List(pListUser args)
        {
            var userB = new bUser();

            return userB.List(args);
        }
    }
}
