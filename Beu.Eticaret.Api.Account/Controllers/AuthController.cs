using Beu.Eticaret.Account.UserToken;
using Beu.Eticaret.Bll.Account;
using Beu.Eticaret.Entity.Account;
using Beu.Eticaret.Web.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Beu.Eticaret.Api.Account.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        public rToken Login(pUser args)
        {
            var tokenB = new bUserToken(_configuration);

            return tokenB.Login(args);
        }

        [HttpPost]
        public rToken CreateTokenByRefreshToken(pbUserToken args)
        {
            var tokenB = new bUserToken(_configuration);

            //System.Diagnostics.Debug.WriteLine(_sharedIdentityService.GetAccessToken);

            return tokenB.CreateTokenByRefreshToken(args);
        }

        [HttpPost]
        public rToken RevokeRefreshToken(pbUserToken args)
        {
            var tokenB = new bUserToken(_configuration);

            return tokenB.RevokeRefreshToken(args);
        }
    }
}
