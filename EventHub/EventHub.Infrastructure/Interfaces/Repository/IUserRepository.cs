using EventHub.Domain;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using EventHub.Infraestructure.Interfaces.Repository;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    interface IUserRepository : IRepository<User>
    {
        Task<bool> CreateUser(User entity);
        Task<bool> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(UserLoginInput user);
    }
}
