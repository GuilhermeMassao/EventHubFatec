using EventHub.Application.GatewayServices.BaseGatewayService;
using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Application.GatewayServices
{
    public class UserGatewayService : GatewayService<Usuario>
    {
        public UserGatewayService(IRepository<Usuario> repository) : base(repository)
        {
        }
    }
}