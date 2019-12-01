using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Domain.Input
{
    public class GoogleAccessTokenInput
    {
        public string Code { get; set; }
        public string CallbackUrl { get; set; }
    }
}
