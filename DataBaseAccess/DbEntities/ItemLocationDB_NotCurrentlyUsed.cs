namespace Entities.Models {
	public class ItemLocationDB : ItemLocation {
		//get item location return superclass (ItemLocation)
		
		
		public int ItemId { get; set; }
		public int LocationId { get; set; }
		
		public ItemLocation GetItemLocation( ) {
			return new ItemLocation {Id = Id, Item = Item, Location = Location, Amount = Amount };
		}
		public override string ToString( ) {
			return $"Location: {Id}" +
			       $"\nItemId: {ItemId}" +
			       $"\nlocationId: {LocationId}" +
			       $"\nAmount: {Amount}";
		}
	}
}