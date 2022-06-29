using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beu.Eticaret.Entity.Cart
{
    public class eCart:eCore
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Piece { get; set; }
        public int UserId { get; set; }
        public string ProductImage { get; set; }
    }
}
