using AutoMapper;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain;
using EventHub.Domain.DTOs.User;

namespace EventHub.Application.Mapping
{
    public class InputToEntity : Profile
    {
        public InputToEntity()
        {
            CreateMap<UserInput, User>();
            CreateMap<UserTokensInput, User>();
        }
    }
}
