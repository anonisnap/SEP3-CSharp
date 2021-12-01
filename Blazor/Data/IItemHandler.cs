using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public interface IItemHandler : IHandler
    {
        //TODO: Jeg mangler i astah ;(
        Task RegisterItem(Item item);
        Task<IList<Item>> GetItems();
        Task<Item> GetItem(int itemId);
    }
}