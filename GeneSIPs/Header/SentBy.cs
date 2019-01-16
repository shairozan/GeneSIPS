using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GeneSIPs.Header
{
    public class SentBy
    {
        public IPAddress Address { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return $"{Address.ToString()}:{Port}";
        }
    }
}
