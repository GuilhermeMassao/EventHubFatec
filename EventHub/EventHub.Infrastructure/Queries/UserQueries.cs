using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Queries
{
    public class UserQueries
    {
        private UserQueries() {}

        public static string CreateUserQuery(User entity)
        {
            return $@"INSERT INTO [User] (UserName, Email, UserPassword)
                        VALUES ('{entity.UserName}', '{entity.Email}', '{entity.UserPassword}');";
        }

        public static string GetByEmailQuery(string email)
        {
            return $@"SELECT * FROM [USER]
                        WHERE Email = '{email}';";
        }

        public static string GetByEmailAndPasswordQuery(UserLoginInput data)
        {
            return $@"SELECT * FROM [USER]
                        WHERE Email = '{data.Email}'
                        AND UserPassword = '{data.UserPassword}'";
        }
    }
}
