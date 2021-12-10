using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class InventoryController : ControllerBase, IInventoryController {

		private IInventoryDataRepo _inventoryRepo;

		public InventoryController(IInventoryDataRepo inventoryDataRepo) {
			_inventoryRepo = inventoryDataRepo;
		}

		[HttpGet]
		[Route("{entityId:int}")]
		public async Task<ActionResult<Inventory>> GetAsync([FromRoute] int entityId) {
			Inventory inventory = await _inventoryRepo.GetAsync(entityId);
			return inventory != null ? Ok(inventory) : NotFound( );
		}

		[HttpGet]
		[Route("itemId/{itemId:int}")]
		public async Task<ActionResult<IList<Inventory>>> GetByItemIdAsync([FromRoute] int itemId) {
			IList<Inventory> itemLocations = await _inventoryRepo.GetByItemIdAsync(itemId);
			
			foreach (var itemLocation in itemLocations)
			{
				Console.WriteLine(itemLocation);
			}
			
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpGet]
		[Route("locationId/{locationId:int}")]
		public async Task<ActionResult<IList<Inventory>>> GetByLocationIdAsync([FromRoute] int locationId) {
			IList<Inventory> itemLocations = await _inventoryRepo.GetInventoryIdAsync(locationId);
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}
		
		[HttpGet]
		[Route("Stock")]
		public async Task<ActionResult<IList<Inventory>>> GetInventoryStock()
		{
			IList<Inventory> itemLocations = await _inventoryRepo.GetInventoryStock();
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpGet]
		public async Task<ActionResult<IList<Inventory>>> GetAllAsync( ) {
			IList<Inventory> itemLocations = await _inventoryRepo.GetAllAsync( );
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpPost]
		[Route("add")]
		public async Task<ActionResult> PostAddAsync([FromBody] Inventory entity) {
			Console.WriteLine($"Attempting to put {entity} in Database");
			Inventory inventory = await _inventoryRepo.AddAsync(entity);
			return inventory != null ? Ok(inventory) : NotFound( );
		}

		[HttpDelete]
		[Route("{entityId:int}")]
		public async Task<ActionResult<Inventory>> DeleteAsync([FromRoute] int entityId) {
			Inventory inventory = await _inventoryRepo.RemoveAsync(entityId);
			return inventory != null ? Ok(inventory) : NotFound( );
		}

		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> PostUpdateAsync([FromBody] Inventory entity) {
			return Ok(await _inventoryRepo.UpdateAsync(entity));
		}
	}
}