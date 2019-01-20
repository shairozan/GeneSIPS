using Bogus;
using GeneSIPs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public Via()
        {

        }

        public Via(Faker<Via> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public string SIPVersion { get; set; } = "SIP/2.0";
        public Protocols Protocol { get; set; } = Protocols.UDP;
        public SipUser SentBy { get; set; }
        public string Branch { get; set; }
        public string RPort { get; set; }
        public static Faker<Via> Faker { get; set; } = Faker = new Faker<Via>()
            .StrictMode(false)
            .RuleFor(o => o.SIPVersion, f => "SIP/2.0")
            .RuleFor(o => o.Branch, f => f.Random.String2(20, "abcdefghijklmnopqrstuvwxyz"))
            .RuleFor(o => o.RPort, f => "rport")
            //.RuleFor(o => o.SentBy, f => )
            .RuleFor(o => o.Protocol, f => f.Random.Enum<Via.Protocols>())
            .RuleFor(o => o.SentBy, f => SipUser.Faker.Generate(1).First())
            ;

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

            sb.Append("\n");

            return sb.ToString();
        }

    }
}
