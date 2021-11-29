using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface ILocationController
    {
        //TODO: Jeg mangler i astah ;(
        Task<ActionResult> GetLocationAsync(string locationId);
        Task<ActionResult> PutLocationAsync(Location location); //FIXME: Giver det mening?
        Task<ActionResult> PostLocationAsync(string locationId, Location location); //Tjek om location eksisterer og så ændrer
        Task<ActionResult<Location>> DeleteLocationAsync(string locationId);

    }
}