using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl
{
	public class LocationDataRepo : ILocationDataRepo
	{
		private WarehouseDbContext _database;

		public LocationDataRepo(WarehouseDbContext dbContext)
		{
			_database = dbContext;
		}

		public async Task<Location> AddAsync(Location location)
		{
			try
			{
				var entityEntry = await _database.Locations.AddAsync(location);
				await _database.SaveChangesAsync();
				return entityEntry.Entity;
			}
			catch (DbUpdateException dbUpdate)
			{
				throw new Exception("Location already in Database", dbUpdate);
			}
		}


		public async Task<Location> UpdateAsync(Location obj)
		{
			var entityEntry = _database.Locations.Update(obj);
			await _database.SaveChangesAsync();
			return entityEntry.Entity;
		}

		public async Task<IList<Location>> GetAllAsync()
		{
			return await _database.Locations.ToListAsync();
		}

		public async Task<Location> GetAsync(int locationId)
		{
			return await _database.Locations.FindAsync(locationId);
		}

		public async Task<Location> RemoveAsync(int id)
		{
			Location locationToRemove = await _database.Locations.FirstAsync(l => l.Id == id);
			// If Location was not found, an Exception should have been thrown on Line Above
			_database.Locations.Remove(locationToRemove);
			return locationToRemove;
		}
	}
}