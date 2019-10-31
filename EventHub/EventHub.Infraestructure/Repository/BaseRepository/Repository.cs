using System.Collections.Generic;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Infraestructure.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /*protected readonly DbContext context;
        public Repository(DbContexnt context)
        {
            this.context = context;
        }
        */
        public int Delete(int id)
        {
            return 1;
        }

        public IEnumerable<TEntity> GetAll()
        {
            // return context.Set<TRentity>().ToList()
            return new List<TEntity>();
        }

        public TEntity GetById(int id)
        {
            // return context.Set<TRentity>().Find(id)
            return null;
        }

        public int Insert(TEntity entity)
        {
            // return context.Set<TRentity>().Add(entity)
            return 1;
        }

        public int Update(int id, TEntity entity)
        {
            return 1;
        }
    }
}
