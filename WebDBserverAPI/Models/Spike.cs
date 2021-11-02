using System.ComponentModel.DataAnnotations;

namespace WebDBserverAPI.Models
{
    public class Spike
    {
        [Key] public string SpikeName { get; set; }
    }
}