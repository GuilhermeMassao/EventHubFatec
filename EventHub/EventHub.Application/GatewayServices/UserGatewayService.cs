using EventHub.Application.GatewayServices.BaseGatewayService;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Application.GatewayServices
{
    public class UserGatewayService : GatewayService<User>
    {
        public UserGatewayService(IRepository<User> repository) : base(repository)
        {
        }
    }
}