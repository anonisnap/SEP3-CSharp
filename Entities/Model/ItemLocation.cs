using System.ComponentModel.DataAnnotations;

namespace Entities.Models {
	public class ItemLocation {
		public int Id { get; set; }
		
		[Required]
		public Location Location { get; set; }
		
		[Required]
		public Item Item { get; set; }

		public int Amount { get; set; }

		public override string ToString( ) {
			return $"ID: {Id}" +
				   $"\tLocation : ( {Location} )" +
				   $"\tItem: ( {Item} )" +
				   $"\tAmount: {Amount}";
		}
		public override bool Equals(object obj) {
			return (obj?.GetType( ) == typeof(ItemLocation)) && Id == ((ItemLocation) obj).Id && Amount == ((ItemLocation) obj).Amount && Item.Equals(((ItemLocation) obj).Item) && Location.Equals(((ItemLocation) obj).Location);
		}

	}
}
