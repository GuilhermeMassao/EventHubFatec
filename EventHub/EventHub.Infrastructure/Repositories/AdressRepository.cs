using EventHub.Domain.Entities;
using EventHub.Infrastructure.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Repositories
{
    public class AdressRepository : IAdressRepository
    {
        public Task<int?> CreateEvent(Adress entity)
        {
            throw new NotImplementedException();
        }
    }
}
