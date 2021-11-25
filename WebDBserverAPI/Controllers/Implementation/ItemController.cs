using System;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase
	{
		private DbContext _database;

		public ItemController(DbContext dbContext)
		{
			_database = dbContext;
		}

		[HttpGet]
		[Route("{itemId:int}")]
		public async Task<ActionResult> GetItemAsync([FromRoute] int itemId)
		{
			Item returnValue = await _database.FindAsync<Item>(itemId);
			if (returnValue != null)
			{
				// Returning Item if found
				return Ok(returnValue);
			}
			else
			{
				// Returning Null if not found
				return NotFound("null");
			}
		}

		[HttpPut]
		public async Task<ActionResult> PutItemAsync([FromBody] Item item)
		{
			// Adds Item to Database
			await _database.AddAsync(item);
			await _database.SaveChangesAsync();
			// Returns URL of created item, as well as the object itself
			return Created($"/Item/{item.Id}", item);
		}

		[HttpDelete]
		[Route("{itemId:int}")]
		public async Task<ActionResult> DeleteItemAsync([FromRoute] int itemId)
		{
			// Find Item which is to be deleted
			Item itemToDelete = await _database.FindAsync<Item>(itemId);
			if (itemToDelete == null)
			{
				// If Item was not found, return 404 not found
				return NotFound();
			}

			// Remove Item
			_database.Remove(itemToDelete);
			// Save Changes done to DB
			await _database.SaveChangesAsync();
			// Return deleted item
			return Ok(itemToDelete);
		}

		[HttpPost]
		[Route("{itemId:int}")]
		public async Task<ActionResult> PostItemAsync([FromRoute] int itemId, [FromBody] Item item)
		{
			// Look for item with given ItemId
			Item existingItem = await _database.FindAsync<Item>(itemId);
			if (existingItem == null)
			{
				// If Item was not found. Create the item in the Database
				item.Id = itemId;
				_database.Add(item);
				_database.SaveChanges();
				return Created($"Item/{itemId}", item);
			}
			else
			{
				// If Item was found. Update the values of the item
				Console.WriteLine("Updating Item");
				item.Id = existingItem.Id; // If Primary Key is different this will cause an error on Value Updates
				_database.Update(existingItem).CurrentValues.SetValues(item); // Update method allows for tracking of item, meaning everything happens as DB stuff
				_database.SaveChanges();
				return Ok(item);
			}
		}
	}
}