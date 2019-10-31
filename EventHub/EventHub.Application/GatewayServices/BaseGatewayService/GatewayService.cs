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
            this._repository = repository;
        }
        public async Task<int> Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<int> Update(int id, TEntity entity)
        {
            return _repository.Update(id, entity);
        }

        public async Task<int> Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
