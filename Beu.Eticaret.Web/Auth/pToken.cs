using Beu.Eticaret.Entity;

namespace Beu.Eticaret.Web.Auth
{
    public class pToken:pId// Token Üretmek için gerekli olan parametrelerin propertilerinin tutulduğu class
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? AccessLevel { get; set; }
    }
}
