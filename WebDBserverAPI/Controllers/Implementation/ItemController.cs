using System;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{
    //TODO: Jeg mangler i astah ;(
    [ApiController] [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private DbContext _database;

        public ItemController(DbContext dbContext)
        {
            Console.WriteLine("ItemController instantiated");
            _database = dbContext;
        }

        [HttpGet]
        [Route("{itemId:int}")]
        public async Task<ActionResult> GetItemAsync([FromRoute] int itemId)
        {
            Item returnValue = await _database.FindAsync<Item>(itemId);
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
        public async Task<ActionResult> PutItemAsync([FromBody] Item item)
        {
            Console.WriteLine("Successfully entered ItemController.PutItemAsync()");
            await _database.AddAsync(item);
            await _database.SaveChangesAsync();
            return Created($"/WarehouseItem/{item.Id}", item);
        }

        [HttpDelete]
        [Route("{itemId:int}")]
        public async Task<ActionResult> DeleteItemAsync([FromRoute] int itemId)
        {
            Console.WriteLine($"Attempting to delete Item ({itemId})");
            Item itemToDelete = await _database.FindAsync<Item>(itemId);
            _database.Remove(itemToDelete);
            await _database.SaveChangesAsync();
            return Ok(itemToDelete);
        }
        
        [HttpPost]
        [Route("{itemId:int}")]
        public async Task<ActionResult> PostItemAsync([FromRoute] int itemId, [FromBody] Item item)
        {
            
            //TODO: Lav mig
            throw new NotImplementedException();
        }
    }
}