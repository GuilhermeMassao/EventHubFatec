//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventHub.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class GoogleCalendarSocialMarketing
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string HashCalendar { get; set; }
        public string CalendarLink { get; set; }
    
        public virtual Event Event { get; set; }
    }
}