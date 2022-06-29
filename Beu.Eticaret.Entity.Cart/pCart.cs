using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beu.Eticaret.Entity.Cart
{
    public class pCart
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Piece { get; set; }
        // Tabloyu oluştururken UserId yi PrimaryKey olarak oluşturmayı unutma...
        public int UserId { get; set; }
        public string ProductImage { get; set; }
    }
}
