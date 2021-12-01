using System.Threading.Tasks;
using Entities.Models;
using ServerCommunication;

namespace Blazor.Data
{
    public interface ILocationHandler : IHandler
    {
        Task CreateLocation(Location location);
    }
}