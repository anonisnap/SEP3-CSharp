using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class OrderEntry
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public int Amount { get; set; }
        
        [ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}