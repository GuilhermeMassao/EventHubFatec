using EventHub.Domain.Entities;
using EventHub.Domain.Exceptions;
using EventHub.Domain.Input;
using EventHub.Infraestructure.Repository;
using EventHub.Infrastructure.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class UserBusiness
    {
        private readonly IUserRepository _repository;

        public UserBusiness()
        {
            _repository = new UserRepository();
        }

        public async Task<User> CreateUser(User entity)
        {
            var resultId = await _repository.CreateUser(entity);
            if (resultId != null)
            {
                var user = await _repository.GetById(resultId.GetValueOrDefault());
                user.Id = resultId.GetValueOrDefault();
                return user;
            }

            return null;
        }

        //public async Task<User> GetById(int id)
        //{
        //    return await _repository.GetById(id);
        //}

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    return await repository.GetAll();
        //}

        //public async Task<bool> Update(int id, User user)
        //{
        //    return await repository.Update(id, user);
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    return await repository.Delete(id);
        //}

        public async Task<User> UserLogin(UserLoginInput input)
        {
            var user = await _repository.GetByEmailAndPassword(input);

            if (user != null)
            {
                if(_repository.GetTwitterTokenByUserId(user.Id) != null)
                {
                    user.HasTwitterLogin = true;
                }
                return user;
            }

            return default(User);
        }

        public async Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input)
        {
            return await _repository.UpdateTwitterToken(id, input);
        }
    }
}
