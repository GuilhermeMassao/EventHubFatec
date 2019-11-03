using System;
using System.Collections.Generic;
using System.Linq;
using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Infraestructure.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EventHubEntities context;
        public Repository(EventHubEntities context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            return 1;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                return 1;
            } catch (Exception e) {
                return -1;
            }
        }

        public int Update(int id, TEntity entity)
        {
            return 1;
        }
    }
}
