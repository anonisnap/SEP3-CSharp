using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface WarehouseItemControllerI
    {
        //TODO: Jeg mangler i astah ;(
        Task<ActionResult> GetWarehouseItemAsync(int warehouseItemId);
        Task<ActionResult> PutWarehouseItemAsync(WarehouseItem warehouseItem);
        Task<ActionResult> DeleteWarehouseItemAsync(int warehouseItemId);
        Task<ActionResult> PostWarehouseItemAsync(int warehouseItemId, WarehouseItem warehouseItem);
        
    }
}