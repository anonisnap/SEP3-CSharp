using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public async Task<Order> UpdateAsync(Order itemLocation)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}