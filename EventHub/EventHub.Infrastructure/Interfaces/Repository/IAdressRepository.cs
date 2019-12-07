using EventHub.Domain.Entities;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IAdressRepository
    {
        Task<int?> CreateAdress(Adress entity);
        Task<int?> EditAdress(int id, Adress entity);
        Task<bool> Delete(int id);
        Task<bool> InactivateAdress(int id);
    }
}
