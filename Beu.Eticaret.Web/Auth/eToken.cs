using System;

namespace Beu.Eticaret.Web.Auth
{
    public class eToken // sona erme sürelerinin içinde tutulduğu dönüş türü 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int? AccessLevel { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
