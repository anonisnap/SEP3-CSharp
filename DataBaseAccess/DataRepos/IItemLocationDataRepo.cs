using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos.Impl
{
    public interface IItemLocationDataRepo : IDataRepo<ItemLocationDB>
    {
        
        Task<List<ItemLocationDB>> GetByItemIdAsync(int itemId);
        
        Task<List<ItemLocationDB>> GetByLocationIdAsync(int locationId);
        
    }
}