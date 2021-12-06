using System.ComponentModel.DataAnnotations;

namespace Entities.Models {
	public class Location {
		public int Id { get; set; }
		[Required, MaxLength(256)]
		public string Description { get; set; }

		public override string ToString( ) {
			return $"Id: {Id} " +
				   $"\n Description: {Description}";
		}

		public override bool Equals(object obj) {
			return (obj?.GetType( ) == typeof(Location)) && Id == ((Location) obj).Id && Description == ((Location) obj).Description;
		}
	}
}
