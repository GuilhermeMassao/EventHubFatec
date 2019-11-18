using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User entity);
        Task<bool> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(UserLoginInput user);
    }
}
