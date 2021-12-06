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
			ItemLocationDB db = await GenerateItemLocationDbAsync(obj);

			EntityEntry<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb.AddAsync(db);
			
			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity.GetItemLocation();
		}

		public async Task<ItemLocation> RemoveAsync(int id) {
			ItemLocationDB location = await _warehouseDbContext.ItemLocationsDb.FindAsync(id);
			EntityEntry<ItemLocationDB> entity = _warehouseDbContext.ItemLocationsDb.Remove(location);
			
			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity.GetItemLocation();
		}

		public async Task<ItemLocation> UpdateAsync(ItemLocation itemLocation)
		{
			ItemLocationDB generatedItemLocationDb = await GenerateItemLocationDbAsync(itemLocation);
			
			// find the old item location db object 
			ItemLocationDB oldItemLocationDb =
				 await _warehouseDbContext.ItemLocationsDb
					 .Include(iLDb => iLDb.Item)
					 .Include(iLDb => iLDb.Location)
					 .Where(iLDb => iLDb.Id == itemLocation.Id)
					 .FirstAsync();
			
			EntityEntry<ItemLocationDB> entity = _warehouseDbContext.ItemLocationsDb.Update(oldItemLocationDb);
			entity.CurrentValues.SetValues(generatedItemLocationDb);
			
			await _warehouseDbContext.SaveChangesAsync( );
			return entity.Entity.GetItemLocation();
		}

		public async Task<IList<ItemLocation>> GetAllAsync( ) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb
				.Include(x => x.Item)
				.Include(x => x.Location)
				.ToListAsync( );
			IList<ItemLocation> result = new List<ItemLocation>( );
			entity.ForEach(x => result.Add(x.GetItemLocation( )));
			
			return result;
		}

		public async Task<ItemLocation> GetAsync(int id) {
			ItemLocationDB entity = await _warehouseDbContext.ItemLocationsDb.FindAsync(id);

			return entity.GetItemLocation();
		}


		public async Task<IList<ItemLocation>> GetByItemIdAsync(int itemId) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb
				.Include(x => x.Item)
				.Include(x => x.Location)
				.Where(ItemLocation => ItemLocation.ItemId == itemId)
				.ToListAsync( );
			
			IList<ItemLocation> result = new List<ItemLocation>();
			entity.ForEach(x => result.Add(x.GetItemLocation()));
			
			return result;
		}

		public async Task<IList<ItemLocation>> GetByLocationIdAsync(int locationId) {
			List<ItemLocationDB> entity = await _warehouseDbContext.ItemLocationsDb.Include(x => x.Item).Include(x => x.Location).Where(ItemLocation => ItemLocation.LocationId == locationId).ToListAsync( );
			IList<ItemLocation> result = new List<ItemLocation>( );
			entity.ForEach(x => result.Add(x.GetItemLocation( )));
			
			return result;
		}

		private async Task<ItemLocationDB> GenerateItemLocationDbAsync(ItemLocation itemLocation) {
			// Retrieve Item and Location from _warehouseDbContext
			Item objItem = await _warehouseDbContext.Items.FirstOrDefaultAsync(x => x.Id == itemLocation.Item.Id);
			Location objLocation = await _warehouseDbContext.Locations.FirstOrDefaultAsync(x => x.Id == itemLocation.Location.Id);

			_warehouseDbContext.ChangeTracker.AcceptAllChanges();
			// Create DB Specific Class with Item and Location from before
			return new ItemLocationDB( ) {Id = itemLocation.Id, Amount = itemLocation.Amount, Item = objItem, Location = objLocation, ItemId = objItem.Id, LocationId = objLocation.Id };
		}
	}
}