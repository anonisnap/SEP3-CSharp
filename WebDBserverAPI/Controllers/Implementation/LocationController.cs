using System;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{/*
    //TODO: Jeg mangler i astah ;(
    [ApiController] [Route("[controller]")]
    public class LocationController : ControllerBase, LocationControllerI
    {
        private DbContext _database;

        public LocationController(DbContext database)
        {
            Console.WriteLine("Location Controller has been instantiated");
            _database = database;
        }

        public async Task<ActionResult> GetLocationAsync(int locationId)
        {
            Location location = await _database.FindAsync<Location>(locationId);
            return Ok(location);
        }

        public async Task<ActionResult> PutLocationAsync(Location location)
        {
            Console.WriteLine("Successfully entered LocationController.PutLocationAsync()");
            await _database.AddAsync(location);
            await _database.SaveChangesAsync();
            return Created($"/WarehouseItem/{location.Id}", location);
        }

        public async Task<ActionResult> DeleteLocationAsync(int locationId)
        {
            Console.WriteLine($"Attempting to delete location ({locationId})");
            Location itemToDelete = await _database.FindAsync<Location>(locationId);
            _database.Remove(itemToDelete);
            await _database.SaveChangesAsync();
            return Ok(itemToDelete);
        }

        public async Task<ActionResult> PostLocationAsync(int locationId, Location location)
        {
            //TODO: lav mig!
            throw new System.NotImplementedException();
        }
        
    }*/
}