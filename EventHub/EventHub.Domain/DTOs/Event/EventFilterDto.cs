using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Domain.DTOs.Event
{
    public class EventFilterDto
    {
        public int UserId { get; set; }
        public int Draw { get; set; }
        public int Length { get; set; }
        public string Order { get; set; }
        public string Search { get; set; }
        public int Start { get; set; }
    }
}
