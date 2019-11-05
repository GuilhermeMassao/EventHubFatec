using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Interfaces.BaseInterfaces
{
    public interface IGatewayService<TEntity>
        where TEntity : class
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<bool> Insert(TEntity input);
        Task<bool> Update(int id, TEntity input);  
    }
}