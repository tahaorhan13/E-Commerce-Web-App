using System;

namespace Beu.Eticaret.Account.UserToken
{
    public class eUserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
