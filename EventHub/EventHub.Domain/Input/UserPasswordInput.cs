using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Domain.Input
{
    public class UserPasswordInput
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
