using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Domain.Services.BaseService
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        public async Task<int> Insert(TEntity dto)
        {
            return 0;
        }

        public async Task<TEntity> GetById(int id)
        {
            return default(TEntity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return new List<TEntity>();
        }

        public async Task<int> Update(int id, TEntity input)
        {
            return default(int);
        }

        public async Task<int> Delete(int id)
        {
            return default(int);
        }
    }
}
