using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Domain.Services.BaseService
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        public async Task<int> Insert(TEntity input)
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
