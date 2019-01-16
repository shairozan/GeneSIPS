using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Header
{
    public class Via
    {
        public enum Protocols
        {
            TCP,
            UDP
        }

        public string SIPVersion { get; set; } = "SIP/2.0";
        public Protocols Protocol { get; set; } = Protocols.UDP;
        public SentBy SentBy { get; set; }
        public string Branch { get; set; }
        public string RPort { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Via: {SIPVersion}");
            sb.Append($"/{Protocol} ");
            sb.Append($"{SentBy.ToString()};");

            if(! string.IsNullOrWhiteSpace(Branch))
            {
                sb.Append($"branch={Branch};");
            }

            if(!string.IsNullOrWhiteSpace(RPort))
            {
                sb.Append($"{RPort}");
            }

            sb.AppendLine();

            return sb.ToString();
        }

    }
}
