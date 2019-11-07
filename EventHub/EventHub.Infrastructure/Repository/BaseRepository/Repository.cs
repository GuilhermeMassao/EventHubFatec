using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Infraestructure.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly EventHubEntities context;
        public Repository(EventHubEntities context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await GetById(id);
                await Task.FromResult(context.Set<TEntity>().Remove(entity));
                context.SaveChanges();

                entity = await GetById(id);

                if(entity != null)
                {
                    return false;
                }

                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> Update(int id, TEntity entity)
        {
            try
            {
                var obj = await GetById(id);
                if(obj != null)
                {
                    context.Entry(obj).CurrentValues.SetValues(entity);
                    context.SaveChanges();

                    if (context.Set<TEntity>().Find(obj) == null)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
