using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDBserverAPI.Controllers
{
    public interface IController<TEntity>
    {
        Task<ActionResult<TEntity>> GetAsync(int entityId);

        Task<ActionResult<IList<TEntity>>> GetAllAsync();
        
        Task<ActionResult> PutAsync(TEntity entity);
        
        Task<ActionResult<TEntity>> DeleteAsync(int entityId);
        
        Task<ActionResult> PostAsync(TEntity entity);
    }
}