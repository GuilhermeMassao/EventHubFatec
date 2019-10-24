using EventHub.Domain.Services.BaseService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Services.BaseServiceApplication
{
    public abstract class ServiceApplication<TInput, TViewModel> :
        IServiceApplication<TInput, TViewModel>
        where TInput : class
        where TViewModel : class
    {
        private readonly IService<TInput, TViewModel> _service;

        public async Task<int> Insert(TInput input)
        {
            return await _service.Insert(input);    
        }

        public async Task<TViewModel> GetById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<int> Update(int id, TInput input)
        {
            return await _service.Update(id, input);
        }

        public async Task<int> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
