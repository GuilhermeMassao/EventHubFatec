using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHubTCC.Models.TO
{
    public class EventAddressTO
    {
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Id { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Número { get; set; }
        public Nullable<int> IdEvento { get; set; }

        public virtual EventTO Evento { get; set; }
    }
}