using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventHubTCC.Models.TO
{
    public class SharingTO
    {
        public string Descricao { get; set; }
        public string Title { get; set; }
        public string Fonte { get; set; }
        public string Id { get; set; }
        public string DataAlteração { get; set; }
        public string Texto { get; set; }
        public Nullable<int> IdTweet { get; set; }
        public Nullable<int> IdAgenda { get; set; }
        public Nullable<int> IdEvento { get; set; }

        public virtual EventTO Evento { get; set; }
    }
}