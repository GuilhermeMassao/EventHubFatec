using System.Collections.Generic;

namespace EventHub.Infraestructure.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Insert(TEntity input);
        int Update(int id, TEntity input); 
    }
}