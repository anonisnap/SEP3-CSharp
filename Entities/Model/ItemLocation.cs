namespace Entities.Models
{
    public class ItemLocation
    {
        public Location Location { get; set; }
        public Item Item { get; set; }
        
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"Location: {Location} \nItem: {Item}, \nAmount: {Amount}";
        }
    }
}
