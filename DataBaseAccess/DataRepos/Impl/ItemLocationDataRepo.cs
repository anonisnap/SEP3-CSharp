using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataBaseAccess.DataRepos.Impl {
	public class ItemLocationDataRepo : IItemLocationDataRepo {
		private WarehouseDbContext _warehouseDbContext;

		public ItemLocationDataRepo(WarehouseDbContext dbContext) {
			_warehouseDbContext = dbContext;
		}


		public async Task<ItemLocation> AddAsync(ItemLocation itemLocation) {
			//ItemLocation itemLocation = await GenerateItemLocationAsync(obj);
			Item objItem = await _warehouseDbContext.Items.FindAsync(itemLocation.Item.Id);
			Location objLocation = await _warehouseDbContext.Locations.FindAsync(itemLocation.Location.Id);
			//todo: maybe not here ?
			itemLocation.Id = 0;
			itemLocation.Item = objItem;
			itemLocation.Location = objLocation;
			EntityEntry<ItemLocation> entity = await _warehouseDbContext.ItemLocations.AddAsync(itemLocation);

			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity;
		}

		public async Task<ItemLocation> RemoveAsync(int id) {
			ItemLocation location = await _warehouseDbContext.ItemLocations.FindAsync(id);
			EntityEntry<ItemLocation> entity = _warehouseDbContext.ItemLocations.Remove(location);

			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity;
		}

		public async Task<ItemLocation> UpdateAsync(ItemLocation itemLocation) {
			
			EntityEntry<ItemLocation> entity = _warehouseDbContext.ItemLocations.Update(itemLocation);

			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity;
		}

		public async Task<IList<ItemLocation>> GetAllAsync( )
		{
			IList<ItemLocation> entity = await _warehouseDbContext.ItemLocations
				.Include(x => x.Item)
				.Include(x => x.Location)
				.ToListAsync();
			
			return entity;
		}

		public async Task<ItemLocation> GetAsync(int id) {
			ItemLocation entity = await _warehouseDbContext.ItemLocations.Include(il => il.Item).Include(il => il.Location).Where(il => il.Id == id).FirstOrDefaultAsync();

			return entity;
		}

		public async Task<IList<ItemLocation>> GetByItemIdAsync(int itemId) {
			
			IList<ItemLocation> entity = await _warehouseDbContext.ItemLocations
				.Include(x => x.Item)
				.Include(x => x.Location)
				.Where(itemLocation => itemLocation.Item.Id == itemId)
				.ToListAsync( );

			return entity;
		}

		public async Task<IList<ItemLocation>> GetByLocationIdAsync(int locationId) {
			List<ItemLocation> entity = await _warehouseDbContext.ItemLocations
				.Include(x => x.Item)
				.Include(x => x.Location)
				.Where(ItemLocation => ItemLocation.Location.Id == locationId)
				.ToListAsync( );
			
			return entity;
		}

		private async Task<ItemLocation> GenerateItemLocationAsync(ItemLocation itemLocation) {
			// Retrieve Item and Location from _warehouseDbContext
			Item objItem = await _warehouseDbContext.Items.FirstOrDefaultAsync(x => x.Id == itemLocation.Item.Id);
			Location objLocation = await _warehouseDbContext.Locations.FirstOrDefaultAsync(x => x.Id == itemLocation.Location.Id);

			_warehouseDbContext.ChangeTracker.AcceptAllChanges( );
			// Create DB Specific Class with Item and Location from before
			return
				new ItemLocation(); //{ Id = itemLocation.Id, Amount = itemLocation.Amount, Item = objItem, Location = objLocation, ItemId = objItem.Id, LocationId = objLocation.Id };
		}
	}
}