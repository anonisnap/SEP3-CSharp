using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public int OrderNumber { get; set; }

        public List<OrderEntry> OrderEntries { get; set; }
        
        public Location Location { get; set; }

        public override string ToString()
        {
            return $"Order:\n" +
                   $"Id: {Id}\n" +
                   $"OrderNumber: {OrderNumber}\n" +
                   $"OrderEntries: {OrderEntries}\n" +
                   $"Location: {Location.Description}";
        }
    }
}