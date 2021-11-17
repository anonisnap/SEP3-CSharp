using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Location = Microsoft.CodeAnalysis.Location;

namespace WebDBserverAPI.Controllers
{
    public interface LocationControllerI
    {
        Task<ActionResult> GetLocationAsync(int locationId);
        Task<ActionResult> PutLocationAsync(Location location); //FIXME: Giver det mening?
        Task<ActionResult> DeleteLocationAsync(int locationId);
        Task<ActionResult> PostLocationAsync(int locationId, Location location); //Tjek om location eksisterer og så ændrer

    }
}