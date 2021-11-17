using System;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3_WebServerClient.Models;

namespace WebDBserverAPI.Controllers
{
    [ApiController] [Route("[controller]")]
    public class WarehouseItemController : ControllerBase, WarehouseItemControllerI
    {
        private DbContext _dbContext;

        public WarehouseItemController(DbContext dbContext)
        {
            Console.WriteLine("WarehouseItemController instantiated");
            _dbContext = dbContext;
        }


        public Task<ActionResult> GetWarehouseItemAsync(int warehouseItemId)
        {
            //TODO: Lav mig
            throw new NotImplementedException();
        }

        public Task<ActionResult> PutWarehouseItemAsync(WarehouseItem warehouseItem)
        {
            //TODO: Lav mig
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteWarehouseItemAsync(int warehouseItemId)
        {
            //TODO: Lav mig
            throw new NotImplementedException();
        }

        public Task<ActionResult> PostWarehouseItemAsync(int warehouseItemId, WarehouseItem warehouseItem)
        {
            //TODO: Lav mig
            throw new NotImplementedException();
        }
    }
}