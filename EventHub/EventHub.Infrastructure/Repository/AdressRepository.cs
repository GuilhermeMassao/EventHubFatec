using EventHub.Domain;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;

namespace EventHub.Infrastructure.Repository
{
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {
        public AdressRepository(EventHubEntities context) : base(context)
        {
        }
    }
}
