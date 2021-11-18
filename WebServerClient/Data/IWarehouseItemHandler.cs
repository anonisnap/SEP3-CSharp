using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace SEP3_WebServerClient.Data
{
    public interface IWarehouseItemHandler
    {
        //TODO: Jeg mangler i astah ;(
        Task NewWarehouseItem(WarehouseItem warehouseItem);
        Task<IList<WarehouseItem>> GetWarehouseItems();
        Task<WarehouseItem> GetWarehouseItem(int itemId);
    }
}