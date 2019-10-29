using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Domain.Services.BaseService
{
    public interface IService<TEntity>
        where TEntity : class
    {
        Task<int> Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<int> Insert(TEntity input);
        Task<int> Update(int id, TEntity input);
    }
}