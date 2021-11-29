using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
    public interface IDataRepo<T>
    {
        Task<T> Add(T obj);
        
        Task<T> Remove(T obj);
        
        Task<T> Update(T obj);
        
        Task<IList<T>> GetAll(T obj);

        Task<T> Get(T obj);

    }
}