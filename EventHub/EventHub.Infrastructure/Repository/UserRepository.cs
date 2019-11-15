using EventHub.Domain.Entities;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using EventHub.Infrastructure.Queries;
using EventHub.Domain.Input;

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
                    await connection.QueryAsync<User>(UserQueries.CreateUserQuery(entity));
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> GetByEmail(string email)
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>(UserQueries.GetByEmailQuery(email));

                return result != null;
            }
        }

        public async Task<User> GetByEmailAndPassword(UserLoginInput input)
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>(UserQueries.GetByEmailAndPasswordQuery(input));

                return result;
            }
        }
    }
}