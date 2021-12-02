using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Item
    {
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

        public override string ToString()
        {
            return $"Id: {Id}, ItemName: {ItemName}, Length: {Length}, Width: {Width}, Height: {Height}, Weight: {Weight}";
        }
    }
    
}
