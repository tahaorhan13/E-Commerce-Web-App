using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Beu.Eticaret.Db.System
{
    [Table("sys_Menu")]
    public partial class sys_Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RoutingUrl { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
    }
}
