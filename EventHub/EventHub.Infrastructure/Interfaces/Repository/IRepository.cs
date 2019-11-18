using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infraestructure.Interfaces.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}