using System;
using System.Collections.Generic;

namespace EventHubApi.Repositories
{
    public class UserRpository : IUserRepository
    {
        public IEnumerable<string> GetAllUsers()
        {
            return new List<string>();
        }
    }
}
