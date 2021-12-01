using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Data
{
    public interface ILocationHandler : IHandler
    {
        Task CreateLocation(Location location);
    }
}