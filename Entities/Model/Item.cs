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
        [Required]
        public string ItemName { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        
    }
    
}
