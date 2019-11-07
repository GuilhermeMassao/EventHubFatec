using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    interface IUserRepository : IRepository<User>
    {
        Task<bool> CreateUser(User entity);
    }
}
