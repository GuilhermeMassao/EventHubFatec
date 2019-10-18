using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;
namespace EventHubTCC.Repository
{
    public class Repository<Tentity> : IReppository<Tentity> where Tentity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(Tentity entitty)
        {
            Context.Set<Tentity>().Add(entitty);
        }

        public void AddRange(Tentity entitty)
        {
            Context.Set<Tentity>().Add(entitty);
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> expression)
        {
            return Context.Set<Tentity>().Where(expression);
        }

        public Tentity Get(int Id)
        {
            return Context.Set<Tentity>().Find(Id);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return Context.Set<Tentity>().ToList();
        }

        public void Remove(Tentity entitty)
        {
            Context.Set<Tentity>().Remove(entitty);
        }

        public void RemoveRange(Tentity entitty)
        {
            Context.Set<Tentity>().Remove(entitty);
        }

        public void Update(Tentity entitty)
        {
            Context.Set<Tentity>().Attach(entitty);
            Context.SaveChanges();
        }
    }
}