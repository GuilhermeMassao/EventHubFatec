using AutoMapper;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Application.Utils;
using EventHub.Business.Business;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Services.UserApplication
{
    public class UserApplication
    {
        private readonly UserBusiness userBusiness;
        private readonly IMapper _inputToEntity;

        public UserApplication(UserBusiness userBusiness, IMapper inputToEntity)
        {
            this.userBusiness = userBusiness;
            _inputToEntity = inputToEntity;
        }

        public async Task<bool> CreateUser(UserInput input)
        {
            if (PayloadValidator.ValidateObject(input))
            {
                return await userBusiness.CreateUser(_inputToEntity.Map<UserInput, User>(input));
            }
            return false;
        }

        public async Task<User> GetById(int id)
        {
            return await userBusiness.GetById(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await userBusiness.GetAll();
        }

        public async Task<bool> Update(int id, UserInput input)
        {
            return await userBusiness.Update(id, _inputToEntity.Map<UserInput, User>(input));
        }

        public async Task<bool> Delete(int id)
        {
            return await userBusiness.Delete(id);
        }

        public async Task<User> UserLogin(UserLoginInput input)
        {
            if (PayloadValidator.ValidateObject(input))
            {
                return await userBusiness.UserLogin(input);
            }
            return null;
        }
    }
}
