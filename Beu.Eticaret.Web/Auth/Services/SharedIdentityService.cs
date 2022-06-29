using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Eltemtek.Teias.Ytes.Web.Auth.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _iHttpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public string GetAccessToken => _iHttpContextAccessor.HttpContext.Request.Headers
            .SingleOrDefault(e => e.Key.Equals("Authorization"))
            .Value.ToString()
            .Split(' ')
            .ElementAt(1);

        public string GetExpirationTime => _iHttpContextAccessor.HttpContext.User.FindFirst("exp").Value;
        public bool HasExpirationTime => _iHttpContextAccessor.HttpContext.User.HasClaim(e => e.Type.Equals("exp"));
    }

    public interface ISharedIdentityService
    {
        public string GetAccessToken { get; }
        public string GetExpirationTime { get; }
        public bool HasExpirationTime { get; }
    }
}
