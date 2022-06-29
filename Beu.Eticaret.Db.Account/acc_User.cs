using System.ComponentModel.DataAnnotations;


namespace Beu.Eticaret.Db.Account
{
    public class acc_User
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int AccessLevel { get; set; }
    }
}
