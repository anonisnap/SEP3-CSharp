using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl
{
	public class LocationDataRepo : ILocationDataRepo
	{
		private SEP_DBContext _database;

		public LocationDataRepo(DbContext dbContext)
		{
			_database = (SEP_DBContext)dbContext;
		}

		public async Task AddAsync(Location location)
		{
			try
			{
				await _database.Locations.AddAsync(location);
				await _database.SaveChangesAsync();
			} catch (DbUpdateException dbUpdate)
			{
				throw new Exception("Location already in Database", dbUpdate);
			}
		}

		public async Task<Location> RemoveAsync(int id)
		{
			Location locationToRemove = await _database.Locations.FindAsync(id);
			if (locationToRemove != null)
			{
				_database.Locations.Remove(locationToRemove);
				return locationToRemove;
			}
			// TODO: Implement Custom Exception
			//throw new LocationFoundException();
			throw new Exception();
		}

		public async Task UpdateAsync(int id, Location obj)
		{
			await AddAsync(obj);
			await RemoveAsync(id);
		}

		public async Task<IList<Location>> GetAllAsync()
		{
			return await _database.Locations.ToListAsync();
		}

		public async Task<Location> GetAsync(int locationId)
		{
			return await _database.Locations.FindAsync(locationId);
		}
	}
}