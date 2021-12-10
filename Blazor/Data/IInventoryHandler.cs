using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public interface IInventoryHandler : IEntityManager<Inventory>
    {
        Task<IList<Inventory>> GetAllByLocationIdAsync(int locationId);
        Task<IList<Inventory>> GetAllByItemIdAsync(int itemId);
    }
}