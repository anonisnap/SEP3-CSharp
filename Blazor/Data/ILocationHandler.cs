using System.Threading.Tasks;
using Entities.Models;

namespace Blazor.Data
{
    public interface ILocationHandler
    {
        Task CreateLocation(Location location);
    }
}