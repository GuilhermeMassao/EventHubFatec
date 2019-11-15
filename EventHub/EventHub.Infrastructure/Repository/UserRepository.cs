using EventHub.Domain.Entities;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Helpers;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

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
                    var obj = await connection.QueryAsync<User>($@"INSERT INTO [User] (UserName, Email, UserPassword)
                                                                        VALUES ('{entity.UserName}', '{entity.Email}', '{entity.UserPassword}');");
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