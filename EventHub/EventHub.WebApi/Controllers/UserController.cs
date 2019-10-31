using EventHub.Application.Services.UserApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain.Entities;
using EventHub.WebApi.Controllers.BaseController;

namespace EventHub.WebApi.Controllers
{
    public class UserController : Controller<UserInput, User>
    {
        public UserController(UserApplication userService) : base(userService) {}
    }
}
