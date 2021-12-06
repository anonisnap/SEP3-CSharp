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
			IList<ItemLocation> itemLocation = await _itemLocationRepo.GetByItemIdAsync(itemId);
			return itemLocation != null ? Ok(itemLocation) : NotFound( );
		}

		[HttpGet]
		[Route("locationId/{locationId:int}")]
		public async Task<ActionResult<IList<ItemLocation>>> GetByLocationIdAsync([FromRoute] int locationId) {
			IList<ItemLocation> itemLocation = await _itemLocationRepo.GetByLocationIdAsync(locationId);
			return itemLocation != null ? Ok(itemLocation) : NotFound( );
		}

		[HttpGet]
		public async Task<ActionResult<IList<ItemLocation>>> GetAllAsync( ) {
			IList<ItemLocation> itemLocations = await _itemLocationRepo.GetAllAsync( );
			return itemLocations != null ? Ok(itemLocations) : NotFound( );
		}

		[HttpPut]
		public async Task<ActionResult> PutAsync([FromBody] ItemLocation entity) {
			System.Console.WriteLine($"Attempting to put {entity} in Database");
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
		public async Task<ActionResult> PostAsync([FromBody] ItemLocation entity) {
			return entity.Id == 0 ? Ok(await _itemLocationRepo.AddAsync(entity)) : Ok(await _itemLocationRepo.UpdateAsync(entity));
		}
	}
}