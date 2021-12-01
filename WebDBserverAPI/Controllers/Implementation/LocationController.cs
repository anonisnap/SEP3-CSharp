using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers {
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class LocationController : ControllerBase, ILocationController {
		private IDataRepo<Location> _locationRepo;

		public LocationController(IDataRepo<Location> locationRepo) {
			_locationRepo = locationRepo;
		}

		[HttpGet]
		[Route("{locationId:int}")]
		public async Task<ActionResult> GetLocationAsync(int? locationId) {
			try {
				
				Location location = await _locationRepo.GetAsync((int) locationId);

				return location != null ? Ok(location) : NotFound( );
			} catch (Exception) {
				return NotFound( );
			}
		}
		
		[HttpGet]
		public async Task<ActionResult> GetLocationsAsync() {
			try {
				
				IList<Location> locations = await _locationRepo.GetAllAsync( );
				
				return locations != null ? Ok(locations) : NotFound( );
			} catch (Exception) {
				return NotFound( );
			}
		}
		
		
		[HttpPut]
		public async Task<ActionResult> PutLocationAsync(Location location) {
			try {
				await _locationRepo.AddAsync(location);
				Console.WriteLine($"+ Location {location.Description}");
				return Created($"/Location/{location.Id}", location);
			} catch (Exception ex) {
				Console.WriteLine("!! Error in Put Location");
				if (ex.Message.Equals("Location already in Database")) {
					return BadRequest(ex.Message);
				}
				return BadRequest( );
			}
		}

		[HttpPost]
		[Route("{locationId:int}")]
		public async Task<ActionResult> PostLocationAsync([FromRoute] int locationId, Location location) {
			await _locationRepo.UpdateAsync(locationId, location);
			return Ok(location);
		}

		[HttpDelete]
		[Route("{locationId:int}")]
		public async Task<ActionResult<Location>> DeleteLocationAsync([FromRoute] int locationId) {
			try {
				Location locationToDelete = await _locationRepo.RemoveAsync(locationId); // TODO: Exception thrown if Object is Null
				return Ok(locationToDelete);
			} catch (Exception e) {
				return StatusCode(500, e.Message);
			}
		}
	}
}