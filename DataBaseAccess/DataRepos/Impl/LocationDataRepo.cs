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
			var returnVal = entityEntry.Entity;

			try {

				int updatedEntries = _warehouseDbContext.SaveChanges( );

				_warehouseDbContext.ChangeTracker.CascadeChanges();

				Console.WriteLine($"Amount of Entries Updated in DB : {updatedEntries}");
			} catch (Exception ex) { Console.WriteLine(ex.StackTrace); }

			foreach (var x in _warehouseDbContext.ChangeTracker.Entries( )) {
				Console.WriteLine($"Entry : {x}");
			}




			Console.WriteLine($"{returnVal.Description} was added with the Id: {returnVal.Id}");

			return returnVal;
		}

		public async Task<Location> RemoveAsync(int LocationId) {
			Console.WriteLine($"Attempting to remove Location with ID : {LocationId}");

			// Find Location which is to be deleted
			Location locationToDelete = await _warehouseDbContext.Locations.FindAsync(LocationId);

			Console.WriteLine($"Location to delete : {(locationToDelete == null ? "Location not found" : locationToDelete)}");

			if (locationToDelete == null) {
				// If Location was not found, return 404 not found
				return null;
			}

			// Remove Location
			var entityEntry = _warehouseDbContext.Locations.Remove(locationToDelete);
			Console.WriteLine($"- Removed : {entityEntry.Entity}"); // FIXME
																	// Save Changes done to DB
			await _warehouseDbContext.SaveChangesAsync( );
			// Return deleted Location
			return entityEntry.Entity;
		}

		public async Task<Location> UpdateAsync(Location location) {
			var entityEntry = _warehouseDbContext.Locations.Update(location);
			entityEntry.CurrentValues.SetValues(location);
			await _warehouseDbContext.SaveChangesAsync( );
			return entityEntry.Entity;
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