using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Interfaces.BaseInterfaces
{
    public interface IServiceApplication<TInput, TEntity>
        where TInput : class
        where TEntity : class
    {
        Task<int> Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<int> Insert(TInput input);
        Task<int> Update(int id, TInput input);
    }
}