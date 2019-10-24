using EventHub.Application.Services.BaseServiceApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Application.Services.UserApplication.ViewModel;

namespace EventHub.Application.Services.UserApplication
{
    public class UserApplication : ServiceApplication<UserInput, UserViewModel>
    {       
    }
}
