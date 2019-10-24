using AutoMapper;
using EventHub.Application.Services.UserApplication.ViewModel;
using EventHub.Domain.DTOs.User;

namespace EventHub.Application.Mapping
{
    public class DtoToViewModel : Profile
    {
        public DtoToViewModel()
        {
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserTokensDTO, UserViewModel>();
        }
    }
}
