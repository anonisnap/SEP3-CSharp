using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public interface IItemLocationDataRepo : IDataRepo<ItemLocation>
    {
        
        Task<IList<ItemLocation>> GetByItemIdAsync(int itemId);
        
        Task<IList<ItemLocation>> GetByLocationIdAsync(int locationId);

        Task<IList<ItemLocation>> GetItemLocationStock();

        
    }
}