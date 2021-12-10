using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	public interface IInventoryController : IController<Inventory>
	{

		public Task<ActionResult<IList<Inventory>>> GetByItemIdAsync(int itemId);
		public Task<ActionResult<IList<Inventory>>> GetByLocationIdAsync(int locationId);
		
		/// <summary>
		/// Gets all item location, excluding the Trashed location
		/// and itemLocations associated with an Order
		/// </summary>
		/// <returns>Task<IList<Inventory>></returns>
		public Task<ActionResult<IList<Inventory>>> GetInventoryStock();
		
		
		
		
		
	}
}