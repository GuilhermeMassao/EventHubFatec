using EventHub.Domain.DTOs.BaseDTO;

namespace EventHub.Domain.DTOs.User
{
    public class UserDTO : DTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }
}
