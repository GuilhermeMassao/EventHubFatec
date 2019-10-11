using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHubTCC.Models.TO
{
    public class EventTO
    {
        public EventTO()
        {
            this.Divulgacaos = new HashSet<SharingTO>();
            this.EnderecoEventoes = new HashSet<EventAddressTO>();
            this.InscritosEventoes = new HashSet<EventSubscribersTO>();
        }

        public int Id { get; set; }
        public Nullable<System.DateTime> DataFim { get; set; }
        public Nullable<System.DateTime> DataInicio { get; set; }
        public string NomeEvento { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> IdUsuario { get; set; }

        public virtual ICollection<SharingTO> Divulgacaos { get; set; }
        public virtual ICollection<EventAddressTO> EnderecoEventoes { get; set; }
        public virtual UserTO Usuario { get; set; }
        public virtual ICollection<EventSubscribersTO> InscritosEventoes { get; set; }
    }
}