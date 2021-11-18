using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3_WebServerClient.Models;

namespace WebDBserverAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SpikeController : ControllerBase
	{
		private DbContext _database;

		public SpikeController(DbContext databaseContext)
		{
			Console.WriteLine("Spike Controller has been instantiated");
			_database = databaseContext;
		}


		[HttpGet]
		[Route("{spikeName}")]
		public async Task<ActionResult> GetSpikeAsync([FromRoute] string spikeName)
		{/*
			Console.WriteLine($"got get spike request");
			return Ok(new Spike{SpikeName = "john"});
			*/
			
			Spike returnValue = await _database.FindAsync<Spike>(spikeName);
			if (returnValue != null)
			{
				Console.WriteLine($"Sending value, {returnValue?.SpikeName}, to Requesting Client");
				return Ok(returnValue);
			}
			else
			{
				return NotFound("null");
			}
		}


		[HttpPut]
		public async Task<ActionResult> PutSpikeAsync([FromBody] Spike spike)
		{
			Console.WriteLine("Successfully entered SpikeController.PutSpikeAsync()");
			await _database.AddAsync(spike);
			await _database.SaveChangesAsync();
			return Created($"/Spike/{spike.SpikeName}", spike);
		}

		[HttpDelete]
		[Route("{spikeName}")]
		public async Task<ActionResult> DeleteSpikeAsync([FromRoute] string spikeName)
		{
			Console.WriteLine($"Attempting to delete Spike ({spikeName})");
			Spike spikeToDelete = await _database.FindAsync<Spike>(spikeName);
			_database.Remove(spikeToDelete);
			await _database.SaveChangesAsync();
			return Ok(spikeToDelete);
		}

		[HttpPost]
		[Route("{spikeName}")]
		public async Task<ActionResult> PostSpikeAsync([FromRoute] string spikeName, [FromBody] Spike updatedSpike)
		{
			Console.WriteLine($"Attempting to Update or Create Spike {spikeName}");
			// Forcing stuff because users are stupid
			updatedSpike.SpikeName = spikeName; // This ensures the SpikeName (from the route) is enforced
			// This way, when creating a spike, no matter what you name it in the body, due to it being a PK, it will always be found at the designated route
			// For changing the PK of an entry, we have to delete and re-create the entry from scratch

			Spike existingSpike = await _database.FindAsync<Spike>(spikeName);
			if (existingSpike != null)
			{
				// This won't work due to "SpikeName" being the Primary Key. Reading the Error code, it mentions to "Delete" and "Create" the object as new instead
				Console.WriteLine($"Updating {existingSpike.SpikeName}");
				Console.WriteLine("Please check SpikeController.cs (PostSpikeAsync())");
				_database.Entry(existingSpike).CurrentValues
					.SetValues(updatedSpike);
			}
			else
			{
				Console.WriteLine($"Creating {updatedSpike.SpikeName}");
				await _database.AddAsync(updatedSpike);
			}

			await _database.SaveChangesAsync();
			return existingSpike == null ? Ok() : Created($"/Spike/{updatedSpike.SpikeName}", updatedSpike);
		}
	}
}