using System.ComponentModel.DataAnnotations;

namespace Entities.Models {
	public class Item {
		public int Id { get; set; }

		[RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
		[Required, MaxLength(100)]
		public string ItemName { get; set; }
		[Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1]")]
		public double Length { get; set; }
		[Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1]")]
		public double Width { get; set; }
		[Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1]")]
		public double Height { get; set; }
		[Range(0.1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0.1]")]
		public double Weight { get; set; }

		public override string ToString( ) {
			return $"Id: {Id} " +
				   $"\nItemName: {ItemName} " +
				   $"\nLength: {Length} " +
				   $"\nWidth: {Width} " +
				   $"\nHeight: {Height} " +
				   $"\nWeight: {Weight}";
		}

		public override bool Equals(object obj) {
			return (obj?.GetType( ) == typeof(Item)) && ItemName == ((Item) obj).ItemName && Height == ((Item) obj).Height && Length == ((Item) obj).Length && Width == ((Item) obj).Width && Weight == ((Item) obj).Weight;
		}
	}

}
