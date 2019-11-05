using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Interfaces.BaseInterfaces
{
    public interface IServiceApplication<TInput, TEntity>
        where TInput : class
        where TEntity : class
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<bool> Insert(TInput input);
        Task<bool> Update(int id, TInput input);
    }
}