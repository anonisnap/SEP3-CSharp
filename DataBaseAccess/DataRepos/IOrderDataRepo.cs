using System.Threading.Tasks;
using Entities.Models;

namespace DataBaseAccess.DataRepos
{
    public interface IOrderDataRepo : IDataRepo<Order>
    {
        
        public Task<int> GetLatestOrderNumber();
        
    }
}