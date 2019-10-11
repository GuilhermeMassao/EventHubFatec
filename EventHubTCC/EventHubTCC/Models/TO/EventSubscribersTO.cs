using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHubTCC.Models.TO
{
    public class EventSubscribersTO
    {
        public string Id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdEvento { get; set; }

        public virtual EventTO Evento { get; set; }
        public virtual UserTO Usuario { get; set; }
    }
}