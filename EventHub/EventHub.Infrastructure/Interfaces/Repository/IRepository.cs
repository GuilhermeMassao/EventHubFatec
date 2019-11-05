using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infraestructure.Interfaces.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<bool> Insert(TEntity input);
        Task<bool> Update(int id, TEntity input); 
    }
}