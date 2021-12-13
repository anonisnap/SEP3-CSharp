using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.GlobalContracts;
using Entities.Models;

namespace Blazor.Data
{
    public interface IInventoryHandler : IEntityManager<Inventory>
    {
        Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId);
        Task<IList<Inventory>> GetAllByItemIdAsync(int itemId);
        Task<IList<Inventory>> GetInventoryStockAsync();

    }
}