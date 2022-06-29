using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Beu.Eticaret.Web.Auth
{
    public static class SignService // kriptolama
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
