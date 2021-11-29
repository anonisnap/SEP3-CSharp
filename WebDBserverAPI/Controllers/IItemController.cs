using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface IItemController
    {
        //TODO: Jeg mangler i astah ;(
        Task<ActionResult> GetItemAsync(int itemId);

        Task<ActionResult<IList<Item>>> GetItemsAsync();
        
        Task<ActionResult> PutItemAsync(Item item);
        Task<ActionResult<Item>> DeleteItemAsync(int itemId);
        Task<ActionResult> PostItemAsync(int itemId, Item item);
        
    }
}