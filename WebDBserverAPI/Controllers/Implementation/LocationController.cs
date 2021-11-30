using System;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
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
		private IDataRepo<Location> _locationRepo;

		public LocationController(IDataRepo<Location> locationRepo)
		{
			Console.WriteLine("Location Controller has been instantiated");
			_locationRepo = locationRepo;
		}

		[HttpGet]
		public async Task<ActionResult> GetLocationAsync(int locationId)
		{
			Location location = await _locationRepo.GetAsync(locationId);
			return location != null ? Ok(location) : NotFound();
		}

		[HttpPut]
		public async Task<ActionResult> PutLocationAsync(Location location)
		{
			await _locationRepo.AddAsync(location);
			return Created($"/WarehouseItem/{location.Id}", location);
		}

		[HttpPost]
		[Route("{locationId:int}")]
		public async Task<ActionResult> PostLocationAsync([FromRoute] int locationId, Location location)
		{
			await _locationRepo.UpdateAsync(locationId, location);
			return Ok(location);
		}

		[HttpDelete]
		[Route("{locationId:int}")]
		public async Task<ActionResult<Location>> DeleteLocationAsync([FromRoute] int locationId)
		{
			try
			{
				Location locationToDelete = await _locationRepo.RemoveAsync(locationId); // TODO: Exception thrown if Object is Null
				return locationToDelete != null ? Ok(locationToDelete) : NotFound();
			}
			catch (Exception e)
			{
				return StatusCode(500, e.Message);
			}
		}
	}
}