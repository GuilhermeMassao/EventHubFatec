using EventHub.Domain.Entities;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using EventHub.Domain.Input;
using EventHub.Infrastructure.Helpers.Interfaces;
using EventHub.Infrastructure.Interfaces.StroreProcedures;
using System.Data;
using EventHub.Infrastructure.Repositories.StoreProcedures;

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
            _storeProcedure = new StoreProcedure();
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
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertUser, 
                        param: parameters, 
                        commandType: CommandType.StoredProcedure
                    );

                    if (createdId != null)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);   
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Email", email, DbType.String);

            using (_connection)
            {
                var user =  await _connection.QueryFirstOrDefaultAsync<User>
                (
                    _storeProcedure.SelectUserByEmail,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                return user;
            }
        }

        public async Task<User> GetByEmailAndPassword(UserLoginInput input)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Email", input.Email, DbType.String);
            parameters.Add("@UserPassword", input.UserPassword, DbType.String);

            using (_connection)
            {
                var user = await _connection.QueryFirstOrDefaultAsync<User>
                (
                    _storeProcedure.SelectUserByEmailAndPassword,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                return user;
            }
        }
    }
}