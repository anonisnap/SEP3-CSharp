using System;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class LocationController : ControllerBase, ILocationController
	{
		private IDataRepo<Location> _locationDataRepo;

		public LocationController(IDataRepo<Location> locationDataRepo)
		{
			Console.WriteLine("Location Controller has been instantiated");
			_locationDataRepo = locationDataRepo;
		}

		[HttpGet]
		public async Task<ActionResult> GetLocationAsync(string locationId)
		{
			Location location = await _locationDataRepo.GetAsync(locationId);
			if (location == null)
			{
				return NotFound();
			}
			return Ok(location);
			
		}

		[HttpPut]
		public async Task<ActionResult> PutLocationAsync(Location location)
		{
			await _locationDataRepo.AddAsync(location);
			return Created($"/WarehouseItem/{location.Id}", location);
		}


		[HttpPost]
		[Route("{locationId}")]
		public async Task<ActionResult> PostLocationAsync([FromRoute] string locationId, Location location)
		{
			throw new NotImplementedException();
			/*
			Location existingLocation = await _database.FindAsync<Location>(locationId);
			if (existingLocation == null)
			{
				// If Location was not found. Create the item in the Database
				location.Id = locationId;
				_database.Add(location);
				_database.SaveChanges();
				return Created($"Item/{location}", location);
			}
			else
			{
				// If Location was found. Update the values of the item
				Console.WriteLine("Updating Item");
				location.Id = existingLocation.Id; // If Primary Key is different this will cause an error on Value Updates
				_database.Update(existingLocation).CurrentValues.SetValues(location); // Update method allows for tracking of location, meaning everything happens as DB stuff
				_database.SaveChanges();
				return Ok(location);
			}*/

		}


		[HttpDelete]
		[Route("{locationId}")]
		public async Task<ActionResult<Location>> DeleteLocationAsync([FromRoute] string locationId)
		{
			try
			{
				Location locationToDelete = await _locationDataRepo.RemoveAsync(locationId);
				return Ok(locationToDelete);
			}
			catch (Exception e)
			{
				
				return StatusCode(500, e.Message);
			}
			
			/*
			Console.WriteLine($"Attempting to Delete Location {locationId}");
			Location locationToDelete = await _database.FindAsync<Location>(locationId);
			if (locationToDelete == null)
			{
				return NotFound();
			}
			
			_database.Remove(locationToDelete);
			await _database.SaveChangesAsync();
			return Ok(locationToDelete);
			*/
			
		}
	}
}