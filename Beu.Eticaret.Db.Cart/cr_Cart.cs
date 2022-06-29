using System.ComponentModel.DataAnnotations;

namespace Beu.Eticaret.Db.Cart
{
    public class cr_Cart
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Piece { get; set; }
        [Required]
        public int UserId { get; set; }
        public string ProductImage { get; set; }
    }
}
