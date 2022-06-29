using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beu.Eticaret.Entity.System.Menu
{
    public class eMenu:eCore
    {
        public string RoutingUrl { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }
        public string Icon { get; set; }
    }
}
