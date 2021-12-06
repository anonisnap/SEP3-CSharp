using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class LocationController : ControllerBase, ILocationController {
		private ILocationDataRepo _locationRepo;

		public LocationController(ILocationDataRepo locationRepo) {
			_locationRepo = locationRepo;
		}

		[HttpGet]
		[Route("{locationId:int}")]
		public async Task<ActionResult<Location>> GetAsync(int locationId) {
			Location location = await _locationRepo.GetAsync(locationId);

			return location != null ? Ok(location) : NotFound( );
		}

		[HttpGet]
		public async Task<ActionResult<IList<Location>>> GetAllAsync( ) {
			IList<Location> locations = await _locationRepo.GetAllAsync( );

			return locations != null ? Ok(locations) : NotFound( );
		}

		[HttpPut]
		public async Task<ActionResult> PutAsync(Location location) {
			await _locationRepo.AddAsync(location);

			return Created($"/Location/{location.Id}", location);
		}


		[HttpDelete]
		[Route("{locationId:int}")]
		public async Task<ActionResult<Location>> DeleteAsync([FromRoute] int locationId) {
			Location locationToDelete = await _locationRepo.RemoveAsync(locationId); // TODO: Exception thrown if Object is Null
			
			return locationToDelete != null ? Ok(locationToDelete) : NotFound( );
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync(Location location) {
			try {
				return location.Id == 0 ? Ok(await _locationRepo.AddAsync(location)) : Ok(await _locationRepo.UpdateAsync(location));
			} catch (Exception e) {
				// Sander siger denne linje som optages af en Kommentar er en Kunstnerisk T�nkepause
				return StatusCode(500, e.Message);
			}
		}
	}
}