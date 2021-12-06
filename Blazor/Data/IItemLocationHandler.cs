using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public interface IItemLocationHandler : IEntityManager<ItemLocation>, IHandler
    {
        Task<IList<ItemLocation>> GetAllByLocationIdAsync(ItemLocation itemLocation);
        Task<IList<ItemLocation>> GetAllByItemIdAsync(ItemLocation itemLocation);
    }
}