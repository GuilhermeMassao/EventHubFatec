using EventHub.Domain.DTOs.BaseDTO;

namespace EventHub.Domain.DTOs.User
{
    public class UserDTO : DTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
