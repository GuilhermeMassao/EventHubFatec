using EventHub.Domain.Entities;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IAdressRepository
    {
        Task<int?> CreateAdress(Adress entity);
        Task<bool> EditAdress(int id, Adress entity);
        Task<Adress> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> InactivateAdress(int id);
    }
}
