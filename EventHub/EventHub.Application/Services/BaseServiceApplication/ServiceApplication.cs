using AutoMapper;
using EventHub.Application.Interfaces.BaseInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Services.BaseServiceApplication
{
    public class ServiceApplication<TInput, TEntity> : IServiceApplication<TInput, TEntity>
        where TInput : class
        where TEntity : class
    {
        private readonly IGatewayService<TEntity> _service;
        private readonly IMapper _inputToEntity;

        public ServiceApplication(IGatewayService<TEntity> service, IMapper inputToEntity)
        {
            _service = service;
            _inputToEntity = inputToEntity;
        }

        public async Task<bool> Insert(TInput input)
        {
            return await _service.Insert(_inputToEntity.Map<TInput, TEntity>(input));
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<bool> Update(int id, TInput input)
        {
            return await _service.Update(id, _inputToEntity.Map<TInput, TEntity>(input));
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
