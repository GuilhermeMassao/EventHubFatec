using AutoMapper;
using EventHub.Application.Mapping;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Services.BaseService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Services.BaseServiceApplication
{
    public class ServiceApplication<TInput, TEntity, TDTO> :
        IServiceApplication<TInput, TEntity, TDTO>
        where TInput : class
        where TEntity : class
        where TDTO : class
    {
        private readonly IService<TEntity, TDTO> _service;
        private readonly IMapper inputToEntity;

        public ServiceApplication(IService<TEntity, TDTO> service)
        {
            this._service = service;
        }

        public async Task<int> Insert(TInput input)
        {
            return await _service.Insert(inputToEntity.Map<TInput, TEntity>(input));
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<int> Update(int id, TInput input)
        {
            return await _service.Update(id, inputToEntity.Map<TInput, TEntity>(input));
        }

        public async Task<int> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}
