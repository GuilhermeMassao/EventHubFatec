using EventHub.Domain.Entities.EntityBase;

namespace EventHub.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string TwitterAcessToken { get; set; }
        public string GoogleRefreshToken { get; set; }
        public bool ActiveUser { get; set; }
        public bool HasTwitterLogin { get; set; }
        public bool HasGoogleLogin { get; set; }
    }
}