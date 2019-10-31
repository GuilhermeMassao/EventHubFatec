using EventHub.Application.GatewayServices.BaseGatewayService;
using EventHub.Domain.Entities;
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