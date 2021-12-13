using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl {
	public class LocationDataRepo : ILocationDataRepo {
		private WarehouseDbContext _warehouseDbContext;

		public LocationDataRepo(WarehouseDbContext dbContext) {
			_warehouseDbContext = dbContext;
		}

		public async Task<Location> AddAsync(Location Location) {
			// Adds Location to Database
			var entityEntry = await _warehouseDbContext.Locations.AddAsync(Location);
			await _warehouseDbContext.SaveChangesAsync( );

			return entityEntry.Entity;
		}

		public async Task<Location> RemoveAsync(int LocationId) {
			// Find Location which is to be deleted
			Location locationToDelete = await _warehouseDbContext.Locations.FindAsync(LocationId);
			if (locationToDelete == null) {
				// If Location was not found, return 404 not found
				return null;
			}

			// Remove Location
			var entityEntry = _warehouseDbContext.Locations.Remove(locationToDelete);
			// Save Changes done to DB
			await _warehouseDbContext.SaveChangesAsync( );
			// Return deleted Location
			return entityEntry.Entity;
		}

		public async Task<Location> UpdateAsync(Location location) {
			var entityEntry = _warehouseDbContext.Locations.Update(location);
			
			await _warehouseDbContext.SaveChangesAsync( );

			return entityEntry.Entity;
		}

		public async Task<IList<Location>> GetAllAsync( ) {
			return await _warehouseDbContext.Locations.ToListAsync( );
		}

		public async Task<Location> GetAsync(int LocationId) {
			return await _warehouseDbContext.Locations.FindAsync(LocationId);
		}
	}
}