using EventHub.Domain.Entities;
using EventHub.Infraestructure.Interfaces.Repository;
using EventHub.Infraestructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class UserBusiness
    {
        private readonly UserRepository repository;

        public UserBusiness(IRepository<User> repository)
        {
            this.repository = (UserRepository) repository;
        }

        public async Task<bool> CreateUser(User entity)
        {
            if(repository.GetByEmail(entity.Email))
            {
                return false;
            }
            return await repository.CreateUser(entity);
        }

        public async Task<User> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<bool> Update(int id, User user)
        {
            return await repository.Update(id, user);
        }

        public async Task<bool> Delete(int id)
        {
            return await repository.Delete(id);
        }

    }
}
