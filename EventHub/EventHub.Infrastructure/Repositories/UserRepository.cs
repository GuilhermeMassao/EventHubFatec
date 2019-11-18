using EventHub.Domain.Entities;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using EventHub.Infrastructure.Queries;
using EventHub.Domain.Input;
using EventHub.Infrastructure.Helpers.Interfaces;
using EventHub.Infrastructure.Interfaces.StroreProcedures;
using System.Data;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private readonly SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public UserRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _connection = new SqlConnection(_dataBaseConnection.ConnectionString());
        }

        public async Task<bool> CreateUser(User entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserName", entity.UserName, DbType.String);
            parameters.Add("@Email", entity.Email, DbType.String);
            parameters.Add("@UserPassword", entity.UserPassword, DbType.String);

            try
            {
                using (_connection)
                {
                    _connection.Execute(_storeProcedure.InsertUser, param: parameters, commandType: CommandType.StoredProcedure);
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