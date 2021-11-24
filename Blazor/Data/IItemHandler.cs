using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Data
{
    public interface IItemHandler
    {
        //TODO: Jeg mangler i astah ;(
        Task RegisterItem(Item item);
        Task<IList<Item>> GetItems();
        Task<Item> GetItem(int itemId);
    }
}