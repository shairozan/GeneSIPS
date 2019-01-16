using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Request
{
    public class RequestUser
    {
        public string UserPart { get; set; }
        public string HostPart { get; set; }

        public override string ToString()
        {
            return $"sip:{UserPart}@{HostPart}";
        }
    }
}
