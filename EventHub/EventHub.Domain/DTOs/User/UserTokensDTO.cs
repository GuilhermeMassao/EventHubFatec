using EventHub.Domain.DTOs.BaseDTO;

namespace EventHub.Domain.DTOs.User
{
    public class UserTokensDTO : DTO
    {
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAcessToken { get; set; }
    }
}
