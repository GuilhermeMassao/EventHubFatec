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
using EventHub.Domain.DTOs.User;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionDatabase _dataBaseConnection;
        private SqlConnection _connection;
        private readonly IStoreProcedure _storeProcedure;

        public UserRepository()
        {
            _dataBaseConnection = new ConnectionHelper();
            _storeProcedure = new StoreProcedure();
        }

        public async Task<int?> CreateUser(User entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UserName", entity.UserName, DbType.String);
            parameters.Add("@Email", entity.Email, DbType.String);
            parameters.Add("@UserPassword", entity.UserPassword, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var createdId = await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.InsertUser, 
                        param: parameters, 
                        commandType: CommandType.StoredProcedure
                    );

                    return createdId;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserDTO> GetById(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);

            using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
            {
                var user = await _connection.QueryFirstOrDefaultAsync<UserDTO>
                (
                    _storeProcedure.SelectUserById,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (user != null)
                {
                    user.Id = id;
                }

                return user;
            }
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Email", email, DbType.String);
            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    _connection.Open();
                    var user = await _connection.QueryFirstOrDefaultAsync<UserDTO>
                    (
                        _storeProcedure.SelectUserByEmail,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return user;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task<User> GetByEmailAndPassword(UserLoginInput input)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Email", input.Email, DbType.String);
            parameters.Add("@UserPassword", input.UserPassword, DbType.String);

            using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
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

        public async Task<bool> Update(int id, User entity)
        {
            var oldUser = GetById(id);

            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.String);
            parameters.Add("@UserName", entity.UserName, DbType.String);
            parameters.Add("@Email", entity.Email, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.ExecuteAsync
                    (
                        _storeProcedure.UpdateUserInformation,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@Id", id, DbType.Int32);

                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    var user = await _connection.ExecuteAsync
                    (
                        _storeProcedure.InactivateUser,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> GetTwitterTokenByUserId(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);

            using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
            {
                var user = await _connection.QueryFirstOrDefaultAsync<User>
                (
                    _storeProcedure.SelectTwitterTokensByUserId,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                return user;
            }
        }

        public async Task<User> GetGoogleTokenByUserId(int id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);

            using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
            {
                var user = await _connection.QueryFirstOrDefaultAsync<User>
                (
                    _storeProcedure.SelectGoogleTokenByUserId,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );

                return user;
            }
        }

        public async Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);
            parameters.Add("@TwitterAccessToken", input.TwitterAccessToken, DbType.String);
            parameters.Add("@TwitterAccessTokenSecret", input.TwitterAccessTokenSecret, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.UpdateUserTwitterToken,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateGoogleToken(int id, GoogleRefreshTokenInput input)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.Int32);
            parameters.Add("@GoogleRefreshToken", input.RefreshToken, DbType.String);

            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.QueryFirstOrDefaultAsync<int?>
                    (
                        _storeProcedure.UpdateUserGoogleToken,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePassword(int id, UserPasswordInput entity)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", id, DbType.String);
            parameters.Add("@UserPassword", entity.NewPassword, DbType.String);
            
            try
            {
                using (_connection = new SqlConnection(_dataBaseConnection.ConnectionString()))
                {
                    await _connection.ExecuteAsync
                    (
                        _storeProcedure.UpdateUserPassword,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}