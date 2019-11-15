using EventHub.Domain.Entities;
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
    }
}
