using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
    public interface IDataRepo<T>
    {
        Task AddAsync(T obj);
        
        Task<T> RemoveAsync(Object id);
        
        Task UpdateAsync(T obj);
        
        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(Object obj);

    }
}