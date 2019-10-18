using EventHubTCC.Models.Entities;
using EventHubTCC.Models.TO;
using EventHubTCC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Business.BO
{
    public class UsuarioBO : Repository<Usuario>
    {
        Repository<Usuario> User;
        public UsuarioBO(DbContext context) : base(context)
        {
            User = new Repository<Usuario>(Context);
        }

        public void Get()
        {
            var query = Context.Set<Usuario>();
            
            var usuario = (from Usu in query
                          where Usu.Id == 1
                          select new UserTO()
                          {
                              Id = Usu.Id,
                              Nome = Usu.Nome,
                          }).ToList().FirstOrDefault();
            usuario.Nome = "Maconha";

            Context.SaveChanges();
        }
    }
}
