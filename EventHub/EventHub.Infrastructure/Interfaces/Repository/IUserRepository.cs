using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<int?> CreateUser(User entity);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(UserLoginInput user);
        Task<User> GetTwitterTokenByUserId(int id);
        Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input);
    }
}
