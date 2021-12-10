using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public interface IInventoryDataRepo : IDataRepo<Inventory>
    {
        
        Task<IList<Inventory>> GetByItemIdAsync(int itemId);
        
        Task<IList<Inventory>> GetInventoryIdAsync(int locationId);

        Task<IList<Inventory>> GetInventoryStock();

        
    }
}