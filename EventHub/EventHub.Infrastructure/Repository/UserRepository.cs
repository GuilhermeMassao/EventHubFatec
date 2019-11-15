using EventHub.Domain.Entities;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        /*
        public async Task<bool> CreateUser(User entity)
        {
            try
            {
                //context.User.Add(entity);
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
        }*/
        public Task<bool> CreateUser(User entity)
        {
            throw new NotImplementedException();
        }

        public bool GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}