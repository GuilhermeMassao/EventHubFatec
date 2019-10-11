using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHubTCC.Models.TO
{
    public class UserTO
    {
        public UserTO()
        {
            this.Eventos = new HashSet<EventTO>();
            this.InscritosEventoes = new HashSet<EventSubscribersTO>();
        }

        public int Id { get; set; }
        public string Senha { get; set; }
        public string TwitterAcessTokenSecret { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string TwitterAcessToken { get; set; }
        public virtual ICollection<EventTO> Eventos { get; set; }
        public virtual ICollection<EventSubscribersTO> InscritosEventoes { get; set; }
    }
}