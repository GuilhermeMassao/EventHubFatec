using EventHub.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IPublicPlaceRepository
    {
        Task<IEnumerable<PublicPlace>> GetAll();
    }
}
