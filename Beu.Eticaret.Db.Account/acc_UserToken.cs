using System;
using System.ComponentModel.DataAnnotations;

namespace Beu.Eticaret.Db.Account.DataAccess
{
    public class acc_UserToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(150)]
        public string RefreshToken { get; set; }
        [Required]
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
