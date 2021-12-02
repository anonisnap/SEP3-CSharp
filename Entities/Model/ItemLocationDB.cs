namespace Entities.Models
{
    public class ItemLocationDB : ItemLocation
    {
        //get item location return superclass (ItemLocation)
        public int Amount { get; set; }
        public int ItemId { get; set;}
        public int LocationId { get; set; }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, locationId: {LocationId}, Amount: {Amount}";
        }
    }
}