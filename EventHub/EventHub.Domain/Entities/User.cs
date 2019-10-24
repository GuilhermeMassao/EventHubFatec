using EventHub.Domain.Entities.BaseEntity;

namespace EventHub.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string TwitterAcessToken { get; set; }
    }
}
