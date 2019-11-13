using EventHub.Domain;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;

namespace EventHub.Infrastructure.Repository
{
    public class PublicPlaceRepository : Repository<PublicPlace>, IPublicPlaceRepository
    {
        public PublicPlaceRepository(EventHubEntities context) : base(context)
        {
        }
    }
}
