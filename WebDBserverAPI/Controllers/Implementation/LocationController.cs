using System;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebDBserverAPI.Controllers
{
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
            //TODO: lav mig!
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> DeleteLocationAsync(int locationId)
        {
            //TODO: lav mig!
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> PostLocationAsync(int locationId, Location location)
        {
            //TODO: lav mig!
            throw new System.NotImplementedException();
        }
        
    }
}