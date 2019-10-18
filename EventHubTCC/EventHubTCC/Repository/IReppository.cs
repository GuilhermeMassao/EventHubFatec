using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTCC.Repository
{
    public interface IReppository<TEntitty> where TEntitty : class, ICustomIdentityDbContex
    {
        TEntitty Get(int Id);
        IEnumerable<TEntitty> GetAll();
        IEnumerable<TEntitty> Find(Expression<Func<TEntitty,bool>> expression);
        void Add(TEntitty entitty);
        void AddRange(TEntitty entitty);
        void Remove(TEntitty entitty);
        void RemoveRange(TEntitty entitty);
        void Update(TEntitty entitty);
    }
}
