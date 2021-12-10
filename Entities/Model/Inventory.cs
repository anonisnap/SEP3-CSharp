using System.ComponentModel.DataAnnotations;

namespace Entities.Models {
	public class Inventory {
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
			return (obj?.GetType( ) == typeof(Inventory)) && Id == ((Inventory) obj).Id && Amount == ((Inventory) obj).Amount && Item.Equals(((Inventory) obj).Item) && Location.Equals(((Inventory) obj).Location);
		}

	}
}
