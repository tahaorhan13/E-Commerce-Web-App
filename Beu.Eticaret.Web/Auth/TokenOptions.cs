using System.Collections.Generic;

namespace Beu.Eticaret.Web.Auth
{
    public class TokenOptions // TokenOption içerisindeki property
    {
        public const string TokenOption= "TokenOption";
        public List<string> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
