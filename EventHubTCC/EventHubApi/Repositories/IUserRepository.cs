using System;
using System.Collections.Generic;

namespace EventHubApi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<string> GetAllUsers();
    }
}
