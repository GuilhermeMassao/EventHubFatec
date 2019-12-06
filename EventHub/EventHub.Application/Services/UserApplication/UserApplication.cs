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
        private readonly UserBusiness _userBusiness;
        private readonly IMapper _inputToEntity;
        private readonly UserInputValidation _userInputValidator;
        private readonly UserTwitterTokensInputValidation _twitterInputValidator;
        private readonly GoogleRefreshTokenInputValidation _googleInputValidation;
        private readonly UserLoginInputValidation _loginValidation;

        public UserApplication(UserBusiness userBusiness, IMapper inputToEntity)
        {
            _userBusiness = userBusiness;
            _inputToEntity = inputToEntity;
            _userInputValidator = new UserInputValidation();
            _twitterInputValidator = new UserTwitterTokensInputValidation();
            _googleInputValidation = new GoogleRefreshTokenInputValidation();
            _loginValidation = new UserLoginInputValidation();
        }

        public async Task<UserDTO> CreateUser(UserInput input)
        {
            if (_userInputValidator.IsValid(input))
            {
                return await _userBusiness.CreateUser(_inputToEntity.Map<UserInput, User>(input));
            }

            return default(UserDTO);
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await _userBusiness.GetById(id);
        }

        public async Task<bool> Update(int id, UserInput input)
        {
            if (_userInputValidator.IsValid(input))
            {
                return await _userBusiness.Update(id, _inputToEntity.Map<UserInput, User>(input));
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            return await _userBusiness.Delete(id);
        }

        public async Task<User> UserLogin(UserLoginInput input)
        {
            if (_loginValidation.IsValid(input))
            {
                return await _userBusiness.UserLogin(input);
            }

            return default(User);
        }

        public async Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input)
        {
            if (_twitterInputValidator.IsValid(input))
            {
                return await _userBusiness.UpdateTwitterToken(id, input);
            }

            return false;
        }

        public async Task<bool> UpdateGoogleToken(int id, GoogleRefreshTokenInput input)
        {
            if (_googleInputValidation.IsValid(input))
            {
                return await _userBusiness.UpdateGoogleToken(id, input);
            }

            return false;
        }
    }
}
