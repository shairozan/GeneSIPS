using Bogus;
using GeneSIPs.Common;
using GeneSIPs.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace GeneTests
{

    public class ViaHeaderTests
    {

        private Regex ViaRegex = new Regex(@"^Via: SIP/[0-9]{1,}\.[0-9]/(TCP|UDP)");

        [Fact]
        public void ToStringWorks()
        {

            Faker<SipUser> sfaker = new Faker<SipUser>()
                .StrictMode(true)
                .RuleFor(o => o.Address, f => IPAddress.Parse(f.Internet.Ip()))
                .RuleFor(o => o.Port, f => f.Random.Number(9000))
                ;

            Faker<Via> vaker = new Faker<Via>()
                .StrictMode(true)
                .RuleFor(o => o.SIPVersion, f=> "SIP/2.0")
                .RuleFor(o => o.Branch, f => f.Random.String2(20,"abcdefghijklmnopqrstuvwxyz"))
                .RuleFor(o => o.RPort,f => "rport")
                //.RuleFor(o => o.SentBy, f => )
                .RuleFor(o => o.Protocol, f => f.Random.Enum<Via.Protocols>())
                .RuleFor(o => o.SentBy, f => sfaker.Generate(1).First())
                ;


            List<string> generated = new List<string>();

            vaker.Generate(50).ForEach(x =>
            {
               generated.Add(x.ToString());
            });


            Assert.Equal(50, generated.Count);
        }
    }
}
