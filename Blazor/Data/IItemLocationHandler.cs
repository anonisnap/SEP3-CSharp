using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public interface IItemLocationHandler : IHandler
    {
        Task AddItemLocation(ItemLocation itemLocation);
    }
}