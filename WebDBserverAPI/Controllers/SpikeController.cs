using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDBserverAPI.Models;

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
		public async Task<ActionResult<String>> GetSpikeAsync([FromRoute] string spikeName)
		{
			Spike returnValue = await _database.FindAsync<Spike>(spikeName);
			Console.WriteLine($"Sending value, {returnValue.SpikeName}, to Requesting Client");
			return Ok(returnValue);
		}


		[HttpPut]
		public async Task<ActionResult> PutSpikeAsync([FromBody] Spike spike)
		{
			Console.WriteLine("Successfully entered SpikeController.PutSpikeAsync()");
			await _database.AddAsync(spike);
			await _database.SaveChangesAsync();
			return Created($"/spike", spike);
		}
	}
}