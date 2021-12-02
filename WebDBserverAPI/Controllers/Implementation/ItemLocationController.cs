using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemLocationController: ControllerBase, IItemLocationController
    {

        private IItemLocationDataRepo _itemLocationDataRepo;

        public ItemLocationController(IItemLocationDataRepo itemLocationDataRepo)
        {
            _itemLocationDataRepo = itemLocationDataRepo;
        }
        
        [HttpGet]
        [Route("{entityId:int}")]
        public async Task<ActionResult<ItemLocation>> GetAsync(int entityId)
        {
            ItemLocation itemLocation = await _itemLocationDataRepo.GetAsync(entityId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
        
        [HttpGet]
        [Route("itemId/{itemId:int}")]
        public async Task<ActionResult<IList<ItemLocation>>> GetByItemIdAsync(int itemId)
        {
            IList<ItemLocation> itemLocation= await _itemLocationDataRepo.GetByItemIdAsync(itemId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
        
        [HttpGet]
        [Route("locationId/{locationId:int}")]
        public async Task<ActionResult<IList<ItemLocation>>> GetByLocationIdAsync(int locationId)
        {
            IList<ItemLocation> itemLocation = await _itemLocationDataRepo.GetByLocationIdAsync(locationId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<ItemLocation>>> GetAllAsync()
        {
            IList<ItemLocation> itemLocations = await _itemLocationDataRepo.GetAllAsync();
            return itemLocations != null ? Ok(itemLocations) : NotFound( );
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(ItemLocation entity)
        {
            ItemLocation itemLocation = await _itemLocationDataRepo.AddAsync(entity);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }

        [HttpDelete]
        public async Task<ActionResult<ItemLocation>> DeleteAsync(int entityId)
        {
            ItemLocation itemLocation = await _itemLocationDataRepo.RemoveAsync(entityId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ItemLocation entity)
        {
            ItemLocation itemLocation = await _itemLocationDataRepo.UpdateAsync(entity);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
    }
}