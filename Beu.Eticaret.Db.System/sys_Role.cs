using System.ComponentModel.DataAnnotations;


namespace Beu.Eticaret.Db.System
{
    public class sys_Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }
        [Required]
        public int AccessLevel { get; set; }
    }
}
