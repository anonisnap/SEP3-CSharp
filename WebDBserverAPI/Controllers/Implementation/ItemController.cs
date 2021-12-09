using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	//TODO: Jeg mangler i astah ;(
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase, IItemController {
		private IItemDataRepo _itemRepo;

		public ItemController(IItemDataRepo itemRepo) {
			_itemRepo = itemRepo;
		}

		[HttpGet]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> GetAsync([FromRoute] int itemId) {
			Item item = await _itemRepo.GetAsync(itemId);

			return item != null ? Ok(item) : NotFound( );
		}

		[HttpGet]
		public async Task<ActionResult<IList<Item>>> GetAllAsync( ) {
			IList<Item> items = await _itemRepo.GetAllAsync( );

			return items != null ? Ok(items) : NotFound( );
		}


		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> PostAddAsync([FromBody] Item item) {
			Console.WriteLine("enter put "+Thread.CurrentThread.Name);
			Console.WriteLine("Putcalled called for item " + item.ItemName + " " + item.Id);
			Item itemAdded = await _itemRepo.AddAsync(item);
			Console.WriteLine("Before return "+Thread.CurrentThread.Name);
			return Created($"/Item/{item.Id}", itemAdded);
		}
		
		[HttpDelete]
		[Route("{itemId:int}")]
		public async Task<ActionResult<Item>> DeleteAsync([FromRoute] int itemId) {
			Item itemToDelete = await _itemRepo.RemoveAsync(itemId);
			
			return itemToDelete != null ? Ok(itemToDelete) : NotFound( );
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> PostUpdateAsync([FromBody] Item item) {
			try {
				return Ok(await _itemRepo.UpdateAsync(item));
			} catch (Exception e) {
				// Sander siger denne linje som optages af en Kommentar er en Kunstnerisk T�nkepause
				return StatusCode(500, e.Message);
			}
		}
	}
}