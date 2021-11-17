using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    internal class WarehouseItemLocations
    {
        public Location Location { get; set; }
        public WarehouseItem Item { get; set; }
        public int Amount { get; set; }
    }
}
