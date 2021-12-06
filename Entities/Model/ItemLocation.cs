namespace Entities.Models {
	public class ItemLocation {
		public int Id { get; set; }
		public Location Location { get; set; }
		public Item Item { get; set; }

		public int Amount { get; set; }

		public override string ToString( ) {
			return $"LocationID: {Id}" +
				   $"\tLocation: {Location} " +
				   $"\tItem: {Item} " +
				   $"\tAmount: {Amount}";
		}
		public override bool Equals(object obj) {
			return (obj?.GetType( ) == typeof(ItemLocation)) && Id == ((ItemLocation) obj).Id && Amount == ((ItemLocation) obj).Amount && Item.Equals(((ItemLocation) obj).Item) && Location.Equals(((ItemLocation) obj).Location);
		}

	}
}
