using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerCommunication
{
    public interface IEntityManager<TEntity>
    {
        Task<TEntity> RegisterAsync(TEntity entity);
        
        Task<TEntity> RemoveAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TEntity entity);
    }
}