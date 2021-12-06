using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseAccess.DataRepos
{
    public interface IDataRepo<TEntity>
    {
        Task<TEntity> AddAsync(TEntity obj);

        Task<TEntity> RemoveAsync(int id);

        Task<TEntity> UpdateAsync(TEntity itemLocation);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);
    }
}