namespace EventHub.Domain.DTOs.User
{
    public class UserTokensDTO
    {
        public int Id { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAcessToken { get; set; }
    }
}
