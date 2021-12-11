using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface IOrderController : IController<Order>
    {
        public Task<ActionResult<int>> GetLatestOrderNumber();
    }
}