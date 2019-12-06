using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<int?> CreateUser(User entity);
        Task<UserDTO> GetById(int id);
        Task<UserDTO> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(UserLoginInput user);
        Task<User> GetTwitterTokenByUserId(int id);
        Task<User> GetGoogleTokenByUserId(int id);
        Task<bool> UpdateTwitterToken(int id, UserTwitterTokensInput input);
        Task<bool> UpdateGoogleToken(int id, GoogleRefreshTokenInput input);
        Task<bool> Update(int id, User entity);
        Task<bool> UpdatePassword(int id, User entity);
        Task<bool> Delete(int id);
    }
}
