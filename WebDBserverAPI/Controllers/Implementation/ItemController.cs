using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase, IItemController
	{
		private IDataRepo<Item> _itemRepo;

		public ItemController(IDataRepo<Item> itemRepo)
		{
			_itemRepo = itemRepo;
		}

		[HttpGet]
		[Route("{itemId:int}")]
		public async Task<ActionResult> GetItemAsync([FromRoute] int itemId)
		{
			Item item = await _itemRepo.GetAsync(itemId);
			
			if (item == null) return NotFound();
			
			return Ok(item);
			
		}
		
		[HttpGet]
		public async Task<ActionResult<IList<Item>>> GetItemsAsync()
		{
			IList<Item> items = await _itemRepo.GetAllAsync();
			
			return Ok(items);
			
		}

		
		[HttpPut]
		public async Task<ActionResult> PutItemAsync([FromBody] Item item)
		{
			await _itemRepo.AddAsync(item);
			return Created($"/Item/{item.Id}", item);
		}

		[HttpDelete]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> DeleteItemAsync([FromRoute] int itemId)
		{
			Item itemToDelete = await _itemRepo.RemoveAsync(itemId);
			return itemToDelete != null ? Ok(itemToDelete) : NotFound();
		}

		[HttpPost]
		[Route("{itemId:int}")]
		public async Task<ActionResult> PostItemAsync([FromRoute] int itemId, [FromBody] Item item)
		{
			try
			{
				await _itemRepo.UpdateAsync(itemId, item);
				return Ok(item);
			}
			catch (Exception e)
			{
				// Sander siger denne linje som optages af en Kommentar er en Kunstnerisk T�nkepause
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