using EventHub.Domain.Entities;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using EventHub.Infrastructure.Queries;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<bool> CreateUser(User entity)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    var obj = await connection.QueryAsync<User>(UserQueries.CreateUserQuery(entity));
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool GetByEmail(string email)
        {
            return false;
        }
    }
}