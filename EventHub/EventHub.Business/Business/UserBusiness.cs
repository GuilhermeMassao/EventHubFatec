﻿using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using EventHub.Infraestructure.Repository;
using EventHub.Infrastructure.Interfaces.Repository;
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

        public async Task<UserDTO> CreateUser(User entity)
        {
            var userWithSameEmail = await _repository.GetByEmail(entity.Email);
            if (userWithSameEmail != null)
            {
                return default(UserDTO);
            }

            var resultId = await _repository.CreateUser(entity);
            if (resultId != null)
            {
                var user = await _repository.GetById(resultId.GetValueOrDefault());
                user.Id = resultId.GetValueOrDefault();
                return user;
            }

            return default(UserDTO);
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Update(int id, User user)
        {
            var userWithSameEmail = await _repository.GetByEmail(user.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != id)
            {
                return false;
            }

            var UserIdNotExist = await _repository.GetById(id) == null;
            if (UserIdNotExist)
            {
                return false;
            }

            return await _repository.Update(id, user);
        }

        public async Task<bool> UpdatePassword(int id, UserPasswordInput input)
        {
            var user = await _repository.GetById(id);
            if (user.UserPassword == input.OldPassword)
            {
                return await _repository.UpdatePassword(id, input);
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
                return await _repository.Delete(id);
            }

            return false;
        }

        public async Task<User> UserLogin(UserLoginInput input)
        {
            var user = await _repository.GetByEmailAndPassword(input);

            if (user != null)
            {
                var userTwitterTokens = await _repository.GetTwitterTokenByUserId(user.Id);
                if (userTwitterTokens.TwitterAccessToken != null && userTwitterTokens.TwitterAccessTokenSecret != null)
                {
                    user.HasTwitterLogin = true;
                }

                var userGoogleToken = await _repository.GetGoogleTokenByUserId(user.Id);

                if (userGoogleToken.GoogleRefreshToken != null)
                {
                    user.HasGoogleLogin = true;
                }
                return user;
            }

            return default(User);
        }

        public async Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
                return await _repository.UpdateTwitterToken(id, input);
            }

            return false;
        }
        
        public async Task<bool> UpdateGoogleToken(int id, GoogleRefreshTokenInput input)
        {
            var user = await _repository.GetById(id);
            if (user != null)
            {
                return await _repository.UpdateGoogleToken(id, input);
            }

            return false;
        }
    }
}
