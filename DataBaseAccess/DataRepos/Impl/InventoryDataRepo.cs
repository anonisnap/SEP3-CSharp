using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataBaseAccess.DataRepos.Impl
{
    public class InventoryDataRepo : IInventoryDataRepo
    {
        private WarehouseDbContext _warehouseDbContext;

        public InventoryDataRepo(WarehouseDbContext dbContext)
        {
            _warehouseDbContext = dbContext;
        }


        public async Task<Inventory> AddAsync(Inventory inventory)
        {
            //Inventory inventory = await GenerateItemLocationAsync(obj);
            Item objItem = await _warehouseDbContext.Items.FindAsync(inventory.Item.Id);
            Location objLocation = await _warehouseDbContext.Locations.FindAsync(inventory.Location.Id);
            //todo: maybe not here ?
            inventory.Id = 0;
            inventory.Item = objItem;
            inventory.Location = objLocation;
            EntityEntry<Inventory> entity = await _warehouseDbContext.Inventory.AddAsync(inventory);

            await _warehouseDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Inventory> RemoveAsync(int id)
        {
            Inventory location = await _warehouseDbContext.Inventory.FindAsync(id);
            EntityEntry<Inventory> entity = _warehouseDbContext.Inventory.Remove(location);

            await _warehouseDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Inventory> UpdateAsync(Inventory inventory)
        {
            EntityEntry<Inventory> entity = _warehouseDbContext.Inventory.Update(inventory);

            await _warehouseDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<IList<Inventory>> GetAllAsync()
        {
            IList<Inventory> entity = await _warehouseDbContext.Inventory
                .Include(x => x.Item)
                .Include(x => x.Location)
                .ToListAsync();
            
            return entity;
        }

        public async Task<Inventory> GetAsync(int id)
        {
            Inventory entity = await _warehouseDbContext.Inventory.Include(il => il.Item)
                .Include(il => il.Location).Where(il => il.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IList<Inventory>> GetByItemIdAsync(int itemId)
        {
            IList<Inventory> entity = await _warehouseDbContext.Inventory
                .Include(x => x.Item)
                .Include(x => x.Location)
                .Where(itemLocation => itemLocation.Item.Id == itemId 
                                       && !itemLocation.Location.Description.StartsWith("o") 
                                       && !itemLocation.Location.Description.Equals("Trashed"))
                .ToListAsync();

            return entity;
        }

        public async Task<IList<Inventory>> GetByLocationIdAsync(int locationId)
        {
            
            List<Inventory> entity = await _warehouseDbContext.Inventory
                .Include(x => x.Item)
                .Include(x => x.Location)
                .Where(itemLocation => itemLocation.Location.Id == locationId 
                                       && !itemLocation.Location.Description.StartsWith("o") 
                                       && !itemLocation.Location.Description.Equals("Trashed"))
                .ToListAsync();
            
            return entity;
        }
        
        
        public async Task<IList<Inventory>> GetInventoryStock()
        {
           var itemLocations = await _warehouseDbContext.Inventory
                .Include(x => x.Item)
                .Include(x => x.Location)
                .Where(itemLocation => !itemLocation.Location.Description.StartsWith("o") 
                                       && !itemLocation.Location.Description.Equals("Trashed"))
                .ToListAsync();
           
           
           
           return itemLocations;
        }

        private async Task<Inventory> GenerateItemLocationAsync(Inventory inventory)
        {
            // Retrieve Item and Location from _warehouseDbContext
            Item objItem = await _warehouseDbContext.Items.FirstOrDefaultAsync(x => x.Id == inventory.Item.Id);
            Location objLocation =
                await _warehouseDbContext.Locations.FirstOrDefaultAsync(x => x.Id == inventory.Location.Id);

            _warehouseDbContext.ChangeTracker.AcceptAllChanges();
            // Create DB Specific Class with Item and Location from before
            return
                new Inventory(); //{ Id = inventory.Id, Amount = inventory.Amount, Item = objItem, Location = objLocation, ItemId = objItem.Id, LocationId = objLocation.Id };
        }
    }
}