namespace Entities.Models {
	public class InventoryDb : Inventory {
		//get item location return superclass (Inventory)
		
		
		public int ItemId { get; set; }
		public int LocationId { get; set; }
		
		public Inventory GetItemLocation( ) {
			return new Inventory {Id = Id, Item = Item, Location = Location, Amount = Amount };
		}
		public override string ToString( ) {
			return $"Location: {Id}" +
			       $"\nItemId: {ItemId}" +
			       $"\nlocationId: {LocationId}" +
			       $"\nAmount: {Amount}";
		}
	}
}