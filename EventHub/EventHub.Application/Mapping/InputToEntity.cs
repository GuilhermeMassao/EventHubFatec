using AutoMapper;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain;

namespace EventHub.Application.Mapping
{
    public class InputToEntity : Profile
    {
        public InputToEntity()
        {
            CreateMap<UserInput, Usuario>();
            CreateMap<UserTokensInput, Usuario>();
        }
    }
}
