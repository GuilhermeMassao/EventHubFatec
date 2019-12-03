using EventHub.Domain.Entities;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Repositories
{
    public class PublicPlaceRepository : IPublicPlaceRepository
    {
        public Task<int?> CreateEvent(PublicPlace entity)
        {
            throw new NotImplementedException();
        }
    }
}
