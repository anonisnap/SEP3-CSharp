using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public interface IItemLocationDataRepo : IDataRepo<Inventory>
    {
        
        Task<IList<Inventory>> GetByItemIdAsync(int itemId);
        
        Task<IList<Inventory>> GetByLocationIdAsync(int locationId);

        Task<IList<Inventory>> GetItemLocationStock();

        
    }
}