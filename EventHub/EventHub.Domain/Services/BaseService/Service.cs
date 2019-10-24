using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Domain.Services.BaseService
{
    public class Service<TInput, TViewModel> : IService<TInput, TViewModel>
        where TInput : class
        where TViewModel : class
    {
        public async Task<int> Insert(TInput input)
        {
            return default(int);
        }

        public async Task<TViewModel> GetById(int id)
        {
            return default(TViewModel);
        }

        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            return default(IEnumerable<TViewModel>);
        }

        public async Task<int> Update(int id, TInput input)
        {
            return default(int);
        }

        public async Task<int> Delete(int id)
        {
            return default(int);
        }
    }
}
