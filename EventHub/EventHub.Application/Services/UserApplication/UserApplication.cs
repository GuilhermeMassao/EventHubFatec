using AutoMapper;
using EventHub.Application.Interfaces.BaseInterfaces;
using EventHub.Application.Services.BaseServiceApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain.Entities;

namespace EventHub.Application.Services.UserApplication
{
    public class UserApplication : ServiceApplication<UserInput, User>
    {
        public UserApplication(IGatewayService<User> service,
        IMapper inputToEntity): base(service, inputToEntity) {}
    }
}
