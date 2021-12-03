namespace Entities.Models
{
    public class ItemLocation
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Item Item { get; set; }
        
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"LocationID: {Id}" +
                   $"\nLocation: {Location} " +
                   $"\nItem: {Item} " +
                   $"\nAmount: {Amount}";
        }
    }
}
