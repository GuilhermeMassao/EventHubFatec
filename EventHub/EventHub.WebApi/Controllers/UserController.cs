using EventHub.Application.Services.BaseServiceApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.WebApi.Controllers.BaseController;

namespace EventHub.WebApi.Controllers
{
    public class UserController : Controller<UserInput, User, UserDTO>
    {
        public UserController(IServiceApplication<UserInput, User, UserDTO> userService) : base(userService) {}
    }
}
