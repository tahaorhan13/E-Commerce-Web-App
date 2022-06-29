using Beu.Eticaret.Entity;
using System;

namespace Beu.Eticaret.Account.UserToken
{
    public class pUserToken: pId
    {
        public string RefreshToken { get; set; }
        public int? UserId { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
