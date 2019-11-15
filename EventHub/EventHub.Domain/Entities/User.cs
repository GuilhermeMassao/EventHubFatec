namespace EventHub.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAcessToken { get; set; }
    }
}
