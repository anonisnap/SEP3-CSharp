using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace SEP3_WebServerClient.Data
{
    public interface IWarehouseItemHandler
    {
        //TODO: Jeg mangler i astah ;(
        Task NewWarehouseItem(Item item);
        Task<IList<Item>> GetWarehouseItems();
        Task<Item> GetWarehouseItem(int itemId);
    }
}