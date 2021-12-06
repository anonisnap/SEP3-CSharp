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
			Console.WriteLine($"Attempting to add {Location.Description} to Database");

			// Adds Location to Database
			var entityEntry = await _warehouseDbContext.Locations.AddAsync(Location);
			await _warehouseDbContext.SaveChangesAsync( );

			Console.WriteLine($"{entityEntry.Entity.Description} was added with the Id: {entityEntry.Entity.Id}");

			return entityEntry.Entity;
		}

		public async Task<Location> RemoveAsync(int LocationId) {
			Console.WriteLine($"Attempting to remove Location with ID : {LocationId}");

			// Find Location which is to be deleted
			Location LocationToDelete = await _warehouseDbContext.Locations.FindAsync(LocationId);
			if (LocationToDelete == null) {
				// If Location was not found, return 404 not found
				return null;
			}

			// Remove Location
			_warehouseDbContext.Locations.Remove(LocationToDelete);
			Console.WriteLine($"- {LocationToDelete.Description}"); // FIXME
																	// Save Changes done to DB
			await _warehouseDbContext.SaveChangesAsync( );
			// Return deleted Location
			return LocationToDelete;
		}

		public async Task<Location> UpdateAsync(Location location) {
			_warehouseDbContext.Locations.Update(location);
			await _warehouseDbContext.SaveChangesAsync( );
			return location;
		}

		public async Task<IList<Location>> GetAllAsync( ) {
			Console.WriteLine($"Returning a list of all Locations to the user\n{_warehouseDbContext.Locations.ToListAsync( ).Result}");
			return await _warehouseDbContext.Locations.ToListAsync( );
		}

		public async Task<Location> GetAsync(int LocationId) {
			return await _warehouseDbContext.Locations.FindAsync(LocationId);
		}
	}
}