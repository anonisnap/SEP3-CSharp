using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
	public interface ILocationController
	{
		Task<ActionResult> GetLocationAsync(int? locationId);
		Task<ActionResult> PutLocationAsync(Location location); //FIXME: Giver det mening?
		Task<ActionResult> PostLocationAsync(int locationId, Location location); //Tjek om location eksisterer og så ændrer
		Task<ActionResult<Location>> DeleteLocationAsync(int locationId);

	}
}