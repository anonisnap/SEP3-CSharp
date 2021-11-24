namespace Entities.Models
{
    public class WarehouseItemLocationDB : WarehouseItemLocation
    {
        public int ItemId { get; set; }
        public string LocationId { get; set; }
    }
}