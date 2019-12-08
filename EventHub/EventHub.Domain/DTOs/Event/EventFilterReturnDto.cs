using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Domain.DTOs.Event
{
    public  class EventFilterReturnDto
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<EventDto> Data { get; set; }
        public int draw { get; set; }
    }
}
