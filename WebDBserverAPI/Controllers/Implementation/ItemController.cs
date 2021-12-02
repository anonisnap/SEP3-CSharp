using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
	
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase, IItemController
	{
		private IItemDataRepo _itemRepo;

		public ItemController(IItemDataRepo itemRepo)
		{
			_itemRepo = itemRepo;
		}

		[HttpGet]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> GetAsync([FromRoute] int itemId)
		{
			Item item = await _itemRepo.GetAsync(itemId);
			
			return item != null ? Ok(item) : NotFound( );
		}
		
		[HttpGet]
		public async Task<ActionResult<IList<Item>>> GetAllAsync()
		{
			IList<Item> items = await _itemRepo.GetAllAsync();
			
			return items != null ? Ok(items) : NotFound( );
		}

		
		[HttpPut]
		public async Task<ActionResult> PutAsync([FromBody] Item item)
		{
			await _itemRepo.AddAsync(item);
			return Created($"/Item/{item.Id}", item);
		}

		[HttpDelete]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> DeleteAsync([FromRoute] int itemId)
		{
			Item itemToDelete = await _itemRepo.RemoveAsync(itemId);
			return itemToDelete != null ? Ok(itemToDelete) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] Item item)
		{
			try
			{
				await _itemRepo.UpdateAsync(item);
				return Ok(item);
			}
			catch (Exception e)
			{
				// Sander siger denne linje som optages af en Kommentar er en Kunstnerisk T�nkepause
				return StatusCode(500, e.Message);
			}
			
			
		}
	}
}