using EventHub.Domain;
using EventHub.Domain.DTOs.User;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EventHubEntities context) : base(context)
        {
        }

        public async Task<bool> CreateUser(User entity)
        {
            try
            {
                User user = new User
                {
                    UserName = "rodrigo",
                    Email = "rodrigo@email.com",
                    UserPassword = "123"
                };
                context.User.Add(user);
                context.SaveChanges();

                if (await context.Set<User>().FindAsync(entity) == null)
                {
                    return false;
                }

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool GetByEmail(string email)
        {
            return context.Set<User>().ToList().Any(user => user.Email == email);
        }
    }
}