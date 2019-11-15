using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EventHub.Infraestructure.Interfaces.Repository;
using EventHub.Infrastructure.Helpers;

namespace EventHub.Infraestructure.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                var obj = await connection.QueryAsync<TEntity>($"DELETE FROM [{typeof(TEntity).Name}] WHERE Id = '{id}'");
                return true;
            }
        }

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
    }
}
