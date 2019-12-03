using EventHub.Domain.Entities;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IPublicPlaceRepository
    {
        Task<int?> CreateEvent(PublicPlace entity);
    }
}
