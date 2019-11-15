using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EventHub.Infraestructure.Interfaces.Repository;
using EventHub.Infrastructure.Helpers;
using EventHub.Domain.Entities;

namespace EventHub.Infraestructure.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /*
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
*/
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                var obj = await connection.QueryAsync<TEntity>($"SELECT * FROM [{typeof(TEntity).Name}]");

                return obj;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                var obj = await connection.QueryFirstOrDefaultAsync<TEntity>($"SELECT * FROM [{typeof(TEntity).Name}] WHERE Id = '{id}'");

                return obj;
            }
        }

        public Task<bool> Update(int id, TEntity input)
        {
            throw new NotImplementedException();
        }
        /*
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
}*/
    }
}
