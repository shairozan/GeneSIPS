using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using GeneSIPs.Response;
using GeneSIPs.Header;

namespace GeneTests
{
    public class ResponseTests
    {
        [Fact]
        public void ParseContactLine()
        {
            string ContactLine = "Contact: <sip:212.242.33.35:5060>";
            Contact parsed = Contact.Parse(ContactLine);

            Assert.NotNull(parsed);
            Assert.Equal("sip", parsed.Protocol);
            Assert.Equal("212.242.33.35", parsed.Address);
            Assert.Equal(5060, parsed.Port);
        }

        [Fact]
        public void ParseCSeq()
        {
            string TestLine = "CSeq: 1 INVITE";
            CSeq parsed = CSeq.Parse(TestLine);

            Assert.NotNull(parsed);
            Assert.True(parsed.Sequence != 0);
        }

        [Fact]
        public void ParseFrom()
        {
            string TestLine = @"From: ""arik"" <sip:voi18062@sip.cybercity.dk>;tag=51449dc";
            From Parsed = From.Parse(TestLine);

            Assert.NotNull(Parsed);
            Assert.NotNull(Parsed.Tag);
            Assert.NotNull(Parsed.User);
            Assert.Equal("arik", Parsed.DisplayName);
            Assert.Equal("voi18062", Parsed.User.User);
            Assert.Equal("sip.cybercity.dk", Parsed.User.Domain);
            Assert.Equal("51449dc", Parsed.Tag);
        }

        [Fact]
        public void ParseProxyAuthentication()
        {
            string TestLine = @"Proxy-Authenticate: Digest realm=""sip.cybercity.dk"",nonce=""1701b4767d49c41117c7b73a255a353"",opaque=""1701a1351f70795"",stale=false,algorithm=MD5";
            ProxyAuthentication Parsed = ProxyAuthentication.Parse(TestLine);

            Assert.NotNull(Parsed);
            Assert.Equal("sip.cybercity.dk", Parsed.DigestRealm);
            Assert.Equal("1701b4767d49c41117c7b73a255a353", Parsed.Nonce);
            Assert.Equal("1701a1351f70795", Parsed.Opaque);
            Assert.False(Parsed.Stale);
            Assert.Equal("MD5", Parsed.Algorithm);
        }
    }
}
