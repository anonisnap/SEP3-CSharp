using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}";
        }
    }
}
