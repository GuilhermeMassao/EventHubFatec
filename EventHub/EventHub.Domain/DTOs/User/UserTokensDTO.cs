namespace EventHub.Domain.DTOs.User
{
    public class UserTokensDTO
    {
        public int Id { get; set; }
        public string TwitterAccessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAccessToken { get; set; }
    }
}
