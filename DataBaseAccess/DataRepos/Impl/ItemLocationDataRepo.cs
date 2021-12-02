using System.Collections.Generic;
using System.Linq;
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


		public async Task<ItemLocation> AddAsync(ItemLocation obj) {
			ItemLocationDB db = await FixItemLocationForDatabaseAsync(obj);

			EntityEntry<ItemLocationDB> entity = _warehouseDbContext.ItemLocationsDb.Add(db);
			await _warehouseDbContext.SaveChangesAsync( );
			
			return entity.Entity.GetItemLocation();
		}

		public async Task<ItemLocation> RemoveAsync(int id) {
			ItemLocationDB location = await _warehouseDbContext.ItemLocationsDb.FindAsync(id);
			EntityEntry<ItemLocationDB> entity = _warehouseDbContext.ItemLocationsDb.Remove(location);
			await _warehouseDbContext.SaveChangesAsync( );
			
			return entity.Entity.GetItemLocation();
		}

		public async Task<ItemLocation> UpdateAsync(ItemLocation obj) {
			ItemLocationDB db = await FixItemLocationForDatabaseAsync(obj);

			EntityEntry<ItemLocationDB> entity = _warehouseDbContext.ItemLocationsDb.Update(db);
			await _warehouseDbContext.SaveChangesAsync( );
			
			return entity.Entity.GetItemLocation();
		}

		public async Task<IList<ItemLocation>> GetAllAsync( ) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb.ToListAsync( );
			IList<ItemLocation> result = new List<ItemLocation>( );
			entity.ForEach(x => result.Add(x.GetItemLocation( )));
			return result;
		}

		public async Task<ItemLocation> GetAsync(int id) {
			ItemLocationDB entity = await _warehouseDbContext.ItemLocationsDb.FindAsync(id);

			return entity.GetItemLocation();
		}


		public async Task<IList<ItemLocation>> GetByItemIdAsync(int itemId) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb.Where(ItemLocation => ItemLocation.ItemId == itemId).ToListAsync( );
			IList<ItemLocation> result = new List<ItemLocation>();
			entity.ForEach(x => result.Add(x.GetItemLocation()));
			return result;
		}

		public async Task<IList<ItemLocation>> GetByLocationIdAsync(int locationId) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb.Where(ItemLocation => ItemLocation.LocationId == locationId).ToListAsync( );
			IList<ItemLocation> result = new List<ItemLocation>( );
			entity.ForEach(x => result.Add(x.GetItemLocation( )));
			return result;
		}

		private async Task<ItemLocationDB> FixItemLocationForDatabaseAsync(ItemLocation itemLocation) {
			// Retrieve Item and Location from _warehouseDbContext
			Item objItem = await _warehouseDbContext.Items.FirstOrDefaultAsync(x => x.Id == itemLocation.Item.Id);
			Location objLocation = await _warehouseDbContext.Locations.FirstOrDefaultAsync(x => x.Id == itemLocation.Location.Id);

			// Create DB Specific Class with Item and Location from before
			return new ItemLocationDB( ) { Amount = itemLocation.Amount, Item = objItem, Location = objLocation, ItemId = objItem.Id, LocationId = objLocation.Id };
		}
	}
}