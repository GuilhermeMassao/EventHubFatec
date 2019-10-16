using System;
using System.Collections.Generic;
using EventHubApi.Repositories;

namespace EventHubApi.Bussiness
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<string> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}
