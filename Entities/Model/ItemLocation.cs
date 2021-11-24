using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ItemLocation
    {
        public Location Location { get; set; }
        public Item Item { get; set; }
        
        public int Amount { get; set; }
    }
}
