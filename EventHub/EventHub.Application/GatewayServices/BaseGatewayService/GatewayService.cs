using System.Collections.Generic;
using System.Threading.Tasks;
using EventHub.Application.Interfaces.BaseInterfaces;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Application.GatewayServices.BaseGatewayService
{
    public class GatewayService<TEntity> : IGatewayService<TEntity>
        where TEntity : class
    {
        private IRepository<TEntity> _repository;

        public GatewayService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Insert(TEntity entity)
        {
            return await _repository.Insert(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<bool> Update(int id, TEntity entity)
        {
            return await _repository.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
