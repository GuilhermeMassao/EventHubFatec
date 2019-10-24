using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Domain.Services.BaseService
{
    public interface IService<TInput, TViewModel>
        where TInput : class
        where TViewModel : class
    {
        Task<int> Delete(int id);
        Task<IEnumerable<TViewModel>> GetAll();
        Task<TViewModel> GetById(int id);
        Task<int> Insert(TInput input);
        Task<int> Update(int id, TInput input);
    }
}