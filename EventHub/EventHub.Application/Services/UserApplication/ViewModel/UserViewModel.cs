using EventHub.Application.Services.BaseServiceApplication.ViewModel;

namespace EventHub.Application.Services.UserApplication.ViewModel
{
    public class UserViewModel : ServiceViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAcessToken { get; set; }
    }
}
