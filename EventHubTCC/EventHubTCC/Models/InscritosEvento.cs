//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventHubTCC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InscritosEvento
    {
        public string Id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdEvento { get; set; }
    
        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
