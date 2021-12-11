using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataRepos.Impl
{
    public class OrderDataRepo : IOrderDataRepo
    {
        private WarehouseDbContext _warehouseDbContext;

        public OrderDataRepo(WarehouseDbContext dbContext)
        {
            _warehouseDbContext = dbContext;
        }
        
        
        public async Task<Order> AddAsync(Order order)
        {
            
            order.OrderEntries.ForEach(entry => entry.Item = _warehouseDbContext.Items.Find(entry.Item.Id));
           
            Console.WriteLine(order);
            var entityEntry = await _warehouseDbContext.Orders.AddAsync(order);
            await _warehouseDbContext.SaveChangesAsync( );

            return entityEntry.Entity;
        }

        public async Task<Order> RemoveAsync(int id)
        {
            //Do we need to be able to remove orders? - Or just some sort of archive?
            throw new System.NotImplementedException();
        }

        public async Task<Order> UpdateAsync(Order itemLocation)
        {
            //TODO: FIX ME
            throw new System.NotImplementedException();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _warehouseDbContext.Orders
                .Include(order => order.OrderEntries).ThenInclude(entry => entry.Item)
                .Include(order => order.Location).ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _warehouseDbContext.Orders.Include(order => order.OrderEntries)
                .Where(order => order.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetLatestOrderNumber()
        {
            Order order = await _warehouseDbContext.Orders.OrderBy(o => o.OrderNumber).LastOrDefaultAsync();
            if (order == null) return 0;
            return order.OrderNumber;
        }
    }
}