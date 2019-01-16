using GeneSIPs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Header
{
    public class To
    {
        public string Address { get; set; }

        public override string ToString()
        {
            return $"To: <sip:{Address}>\r\n";
        }
    }
}
