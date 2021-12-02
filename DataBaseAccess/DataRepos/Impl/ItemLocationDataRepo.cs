using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl
{
    public class ItemLocationDataRepo : IItemLocationDataRepo
    {
        private WarehouseDbContext _warehouseDbContext;

        public ItemLocationDataRepo(WarehouseDbContext dbContext)
        {
            _warehouseDbContext = dbContext;
        }


        public async Task<ItemLocationDB> AddAsync(ItemLocationDB obj)
        {
            _warehouseDbContext.ItemLocationsDb.Add(obj);
            await _warehouseDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<ItemLocationDB> RemoveAsync(int id)
        {
            ItemLocationDB location = await _warehouseDbContext.ItemLocationsDb.FindAsync(id);
            _warehouseDbContext.ItemLocationsDb.Remove(location);
            await _warehouseDbContext.SaveChangesAsync();
            return location;
        }

        public async Task<ItemLocationDB> UpdateAsync(ItemLocationDB obj)
        {
            _warehouseDbContext.ItemLocationsDb.Update(obj);
            await _warehouseDbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<IList<ItemLocationDB>> GetAllAsync()
        {
            return await _warehouseDbContext.ItemLocationsDb.ToListAsync();
        }

        public async Task<ItemLocationDB> GetAsync(int id)
        {
            return await _warehouseDbContext.ItemLocationsDb.FindAsync(id);
        }


        public async Task<List<ItemLocationDB>> GetByItemIdAsync(int itemId)
        {
            return await _warehouseDbContext.ItemLocationsDb.Where(ItemLocation => ItemLocation.ItemId == itemId)
                .ToListAsync();
        }

        public async Task<List<ItemLocationDB>> GetByLocationIdAsync(int locationId)
        {
            return await _warehouseDbContext.ItemLocationsDb
                .Where(ItemLocation => ItemLocation.LocationId == locationId).ToListAsync();
        }
    }
}