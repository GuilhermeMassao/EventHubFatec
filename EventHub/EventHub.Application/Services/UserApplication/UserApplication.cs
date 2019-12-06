using AutoMapper;
using EventHub.Application.Services.UserApplication.Validations;
using EventHub.Application.Utils;
using EventHub.Business.Business;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Threading.Tasks;
namespace EventHub.Application.Services.UserApplication
{
    public class UserApplication
    {
        private readonly UserBusiness userBusiness;
        private readonly IMapper _inputToEntity;
        private readonly UserInputValidation _validator;

        public UserApplication(UserBusiness userBusiness, IMapper inputToEntity)
        {
            this.userBusiness = userBusiness;
            _inputToEntity = inputToEntity;
            _validator = new UserInputValidation();
        }

        public async Task<UserDTO> CreateUser(UserInput input)
        {
            if (_validator.IsValid(input))
            {
                return await userBusiness.CreateUser(_inputToEntity.Map<UserInput, User>(input));
            }

            return default(UserDTO);
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await userBusiness.GetById(id);
        }

        public async Task<bool> Update(int id, UserInput input)
        {
            if (_validator.isValidUserUpdate(input))
            {
                return await userBusiness.Update(id, _inputToEntity.Map<UserInput, User>(input));
            }

            return false;
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

        public async Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input)
        {
            return await userBusiness.UpdateTwitterToken(id, input);
        }
        public async Task<bool> UpdateGoogleToken(int id, GoogleRefreshTokenInput input)
        {
            return await userBusiness.UpdateGoogleToken(id, input);
        }
    }
}
