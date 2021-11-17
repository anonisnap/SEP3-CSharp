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
        private DbContext _database;

        public WarehouseItemController(DbContext dbContext)
        {
            Console.WriteLine("WarehouseItemController instantiated");
            _database = dbContext;
        }

        [HttpGet]
        [Route("{warehouseItemId}")]
        public async Task<ActionResult> GetWarehouseItemAsync([FromRoute] int warehouseItemId)
        {
            WarehouseItem returnValue = await _database.FindAsync<WarehouseItem>(warehouseItemId);
            if (returnValue != null)
            {
                Console.WriteLine($"Sending value, {returnValue?.Id}, to Requesting Client");
                return Ok(returnValue);
            }
            else
            {
                return NotFound("null");
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutWarehouseItemAsync([FromBody] WarehouseItem warehouseItem)
        {
            Console.WriteLine("Successfully entered WarehouseItemController.PutWarehouseItemAsync()");
            await _database.AddAsync(warehouseItem);
            await _database.SaveChangesAsync();
            return Created($"/WarehouseItem/{warehouseItem.Id}", warehouseItem);
        }

        [HttpDelete]
        [Route("{warehouseItemId}")]
        public async Task<ActionResult> DeleteWarehouseItemAsync([FromRoute] int warehouseItemId)
        {
            Console.WriteLine($"Attempting to delete warehouseItem ({warehouseItemId})");
            WarehouseItem warehouseItemToDelete = await _database.FindAsync<WarehouseItem>(warehouseItemId);
            _database.Remove(warehouseItemToDelete);
            await _database.SaveChangesAsync();
            return Ok(warehouseItemToDelete);
        }

        [HttpPost]
        [Route("{warehouseItemId}")]
        public async Task<ActionResult> PostWarehouseItemAsync([FromRoute] int warehouseItemId, [FromBody] WarehouseItem warehouseItem)
        {
            //TODO: Lav mig
            throw new NotImplementedException();
        }
    }
}