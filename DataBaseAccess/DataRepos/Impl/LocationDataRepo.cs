using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl
{
	public class LocationDataRepo : IDataRepo<Location>
	{

		private SEP_DBContext _sepDbContext;

		public LocationDataRepo(DbContext dbContext)
		{
			_sepDbContext = (SEP_DBContext)dbContext;
		}


		public async Task AddAsync(Location location)
		{
			await _sepDbContext.Locations.AddAsync(location);
			await _sepDbContext.SaveChangesAsync();
		}

		public async Task<Location> RemoveAsync(object id)
		{
			Location locationToRemove = await _sepDbContext.Locations.FindAsync((string)id);

			_sepDbContext.Locations.Remove(locationToRemove);

			return locationToRemove;
		}

		public async Task UpdateAsync(Location obj)
		{
			throw new System.NotImplementedException();
		}

		public async Task<IList<Location>> GetAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public async Task<Location> GetAsync(object locationId)
		{
			return await _sepDbContext.Locations.FindAsync((string)locationId);
		}
	}
}