using System.ComponentModel.DataAnnotations;

namespace Beu.Eticaret.Db.Product
{
    public class pr_Bileklik
    {
        [Key]
        public int? Id { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public string ProductPrice { get; set; }
        [StringLength(100)]
        public string ProductImage { get; set; }
    }
}
