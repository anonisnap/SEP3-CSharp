using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase, IItemController
	{
		private IDataRepo<Item> _itemDataRepo;

		public ItemController(IDataRepo<Item> itemDataRepo)
		{
			_itemDataRepo = itemDataRepo;
		}

		[HttpGet]
		[Route("{itemId:int}")]
		public async Task<ActionResult> GetItemAsync([FromRoute] int itemId)
		{
			Item item = await _itemDataRepo.GetAsync(itemId);
			
			if (item == null) return NotFound();
			
			return Ok(item);
			
		}
		
		[HttpGet]
		public async Task<ActionResult<IList<Item>>> GetItemsAsync()
		{
			IList<Item> items = await _itemDataRepo.GetAllAsync();
			
			return Ok(items);
			
		}

		
		[HttpPut]
		public async Task<ActionResult> PutItemAsync([FromBody] Item item)
		{
			await _itemDataRepo.AddAsync(item);
			return Created($"/Item/{item.Id}", item);
		}

		[HttpDelete]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> DeleteItemAsync([FromRoute] int itemId)
		{
			Item itemToDelete = await _itemDataRepo.RemoveAsync(itemId);
			
			if (itemToDelete == null)
			{
				return NotFound();
			}

			return Ok(itemToDelete);
			
		}

		[HttpPost]
		[Route("{itemId:int}")]
		public async Task<ActionResult> PostItemAsync([FromRoute] int itemId, [FromBody] Item item)
		{
			try
			{
				await _itemDataRepo.UpdateAsync(item);
				return Ok(item);
			}
			catch (Exception e)
			{
				
				return StatusCode(500, e.Message);
			}
			
			
			/*
			// Look for item with given ItemId
			Item existingItem = await _database.FindAsync<Item>(itemId);
			if (existingItem == null)
			{
				// If Item was not found. Create the item in the Database
				item.Id = itemId;
				_database.Add(item);
				_database.SaveChanges();
				Console.WriteLine($"+ {item.ItemName}"); // FIXME
				return Created($"Item/{itemId}", item);
			}
			else
			{
				// If Item was found. Update the values of the item
				item.Id = existingItem.Id; // If Primary Key is different this will cause an error on Value Updates
				_database.Update(existingItem).CurrentValues.SetValues(item); // Update method allows for tracking of item, meaning everything happens as DB stuff
				_database.SaveChanges();
				Console.WriteLine($"o {existingItem.ItemName}"); // FIXME
				return Ok(item);
			}*/
			
		}
	}
}