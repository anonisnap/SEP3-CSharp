using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers {
	public interface IItemLocationController : IController<ItemLocation>
	{

		public Task<ActionResult<IList<ItemLocation>>> GetByItemIdAsync(int itemId);
		public Task<ActionResult<IList<ItemLocation>>> GetByLocationIdAsync(int locationId);
		
		/// <summary>
		/// Gets all item location, excluding the Trashed location
		/// and itemLocations associated with an Order
		/// </summary>
		/// <returns>Task<IList<ItemLocation>></returns>
		public Task<ActionResult<IList<ItemLocation>>> GetItemLocationStock();
		
		
		
		
		
	}
}