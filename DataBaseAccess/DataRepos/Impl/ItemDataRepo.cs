using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl {
	public class ItemDataRepo : IItemDataRepo {
		private WarehouseDbContext _warehouseDbContext;

		public ItemDataRepo(WarehouseDbContext dbContext) {
			_warehouseDbContext = dbContext;
		}

		public async Task<Item> AddAsync(Item item) {
			// Adds Item to Database
			var entityEntry = await _warehouseDbContext.Items.AddAsync(item);
			await _warehouseDbContext.SaveChangesAsync( );

			return entityEntry.Entity;
		}

		public async Task<Item> RemoveAsync(int itemId) {
			// Find Item which is to be deleted
			Item itemToDelete = await _warehouseDbContext.Items.FindAsync(itemId);
			if (itemToDelete == null) {
				// If Item was not found, return 404 not found
				return null;
			}

			// Remove Item
			_warehouseDbContext.Items.Remove(itemToDelete);
			// Save Changes done to DB
			await _warehouseDbContext.SaveChangesAsync( );
			// Return deleted item
			return itemToDelete;
		}

		public async Task<Item> UpdateAsync(Item item) {
			var entityEntry = _warehouseDbContext.Items.Update(item);

			entityEntry.CurrentValues.SetValues(item);

			await _warehouseDbContext.SaveChangesAsync( );

			return entityEntry.Entity;
		}

		public async Task<IList<Item>> GetAllAsync( ) {
			return await _warehouseDbContext.Items.ToListAsync( );
		}

		public async Task<Item> GetAsync(int itemId) {
			return await _warehouseDbContext.Items.FindAsync(itemId);
		}
	}
}