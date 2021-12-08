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
        
        
        public async Task<Order> AddAsync(Order obj)
        {
            throw new System.NotImplementedException();
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
            return await _warehouseDbContext.Orders.Include(order => order.OrderEntries).ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _warehouseDbContext.Orders.Include(order => order.OrderEntries)
                .Where(order => order.Id == id).FirstOrDefaultAsync();
        }
    }
}