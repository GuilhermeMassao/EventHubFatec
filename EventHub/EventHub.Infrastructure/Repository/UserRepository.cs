using EventHub.Domain;
using EventHub.Infraestructure.Repository.BaseRepository;

namespace EventHub.Infraestructure.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EventHubEntities context) : base(context)
        {
        }
    }
}