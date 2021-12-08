namespace Entities.Models
{
    public class OrderEntry
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public Item Item { get; set; }
    }
}