using Beu.Eticaret.Entity;

namespace Beu.Eticaret.Account.UserToken
{
    public class pbUserToken: pId
    {
       
        public int? UserId { get; set; }
        public string RefreshToken { get; set; }

    }
}
