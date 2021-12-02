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
        public async Task<ActionResult<ItemLocationDB>> GetAsync(int entityId)
        {
            ItemLocationDB itemLocation= await _itemLocationDataRepo.GetAsync(entityId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
        
        [HttpGet]
        [Route("itemId/{itemId:int}")]
        public async Task<ActionResult<IList<ItemLocationDB>>> GetByItemIdAsync(int itemId)
        {
            IList<ItemLocationDB> itemLocationDb= await _itemLocationDataRepo.GetByItemIdAsync(itemId);
            return itemLocationDb != null ? Ok(itemLocationDb) : NotFound( );
        }
        
        [HttpGet]
        [Route("locationId/{locationId:int}")]
        public async Task<ActionResult<IList<ItemLocationDB>>> GetByLocationIdAsync(int locationId)
        {
            IList<ItemLocationDB> itemLocationDb = await _itemLocationDataRepo.GetByLocationIdAsync(locationId);
            return itemLocationDb != null ? Ok(itemLocationDb) : NotFound( );
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<ItemLocationDB>>> GetAllAsync()
        {
            IList<ItemLocationDB> itemLocationDbs = await _itemLocationDataRepo.GetAllAsync();
            return itemLocationDbs != null ? Ok(itemLocationDbs) : NotFound( );
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(ItemLocationDB entity)
        {
            ItemLocationDB itemLocation = await _itemLocationDataRepo.AddAsync(entity);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }

        [HttpDelete]
        public async Task<ActionResult<ItemLocationDB>> DeleteAsync(int entityId)
        {
            ItemLocationDB itemLocation = await _itemLocationDataRepo.RemoveAsync(entityId);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ItemLocationDB entity)
        {
            ItemLocationDB itemLocation = await _itemLocationDataRepo.UpdateAsync(entity);
            return itemLocation != null ? Ok(itemLocation) : NotFound( );
        }
    }
}