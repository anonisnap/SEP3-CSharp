using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class ItemLocationController : ControllerBase, IItemLocationController {

		private IItemLocationDataRepo _itemLocationRepo;

		public ItemLocationController(IItemLocationDataRepo itemLocationDataRepo) {
			_itemLocationRepo = itemLocationDataRepo;
		}

		[HttpGet]
		[Route("{entityId:int}")]
		public async Task<ActionResult<ItemLocation>> GetAsync([FromRoute] int entityId) {
			ItemLocation itemLocation = await _itemLocationRepo.GetAsync(entityId);
			return itemLocation != null ? Ok(itemLocation) : NotFound( );
		}

		[HttpGet]
		[Route("itemId/{itemId:int}")]
		public async Task<ActionResult<IList<ItemLocation>>> GetByItemIdAsync([FromRoute] int itemId) {
			IList<ItemLocation> itemLocations = await _itemLocationRepo.GetByItemIdAsync(itemId);
			
			foreach (var itemLocation in itemLocations)
			{
				Console.WriteLine(itemLocation);
			}
			
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpGet]
		[Route("locationId/{locationId:int}")]
		public async Task<ActionResult<IList<ItemLocation>>> GetByLocationIdAsync([FromRoute] int locationId) {
			IList<ItemLocation> itemLocations = await _itemLocationRepo.GetByLocationIdAsync(locationId);
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}
		
		[HttpGet]
		[Route("Stock")]
		public async Task<ActionResult<IList<ItemLocation>>> GetItemLocationStock()
		{
			IList<ItemLocation> itemLocations = await _itemLocationRepo.GetItemLocationStock();
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpGet]
		public async Task<ActionResult<IList<ItemLocation>>> GetAllAsync( ) {
			IList<ItemLocation> itemLocations = await _itemLocationRepo.GetAllAsync( );
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> PostAddAsync([FromBody] ItemLocation entity) {
			Console.WriteLine($"Attempting to put {entity} in Database");
			ItemLocation itemLocation = await _itemLocationRepo.AddAsync(entity);
			return itemLocation != null ? Ok(itemLocation) : NotFound( );
		}

		[HttpDelete]
		[Route("{entityId:int}")]
		public async Task<ActionResult<ItemLocation>> DeleteAsync([FromRoute] int entityId) {
			ItemLocation itemLocation = await _itemLocationRepo.RemoveAsync(entityId);
			return itemLocation != null ? Ok(itemLocation) : NotFound( );
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> PostUpdateAsync([FromBody] ItemLocation entity) {
			return Ok(await _itemLocationRepo.UpdateAsync(entity));
		}
	}
}