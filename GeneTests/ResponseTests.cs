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

        [Fact]
        public void ParseServer()
        {
            string TestLine = @"Server: Cirpack/v4.38e (gw_sip)";

            Server s = Server.Parse(TestLine);

            Assert.NotNull(s);
            Assert.Equal("Cirpack", s.Name);
            Assert.Equal("v4.38e", s.VersionIdentifier);
            Assert.Equal("gw_sip", s.Type);
        }

        [Fact]
        public void ParseEntireResponse()
        {
            string TestLine = @"SIP/2.0 407 authentication required
Allow: UPDATE,REFER
Call - ID: 85216695 - 42dcdb1d@192.168.1.2
Contact: < sip:212.242.33.35:5060 >
 CSeq: 1 INVITE
 From: ""arik"" < sip:voi18062 @sip.cybercity.dk >; tag = 51449dc
Proxy - Authenticate: Digest realm = ""sip.cybercity.dk"", nonce = ""1701b4767d49c41117c7b73a255a353"", opaque = ""1701a1351f70795"", stale = false, algorithm = MD5
Server: Cirpack / v4.38e(gw_sip)
To: < sip:0097239287044@sip.cybercity.dk >; tag = 00 - 04073 - 1701b482 - 069239f90
Via: SIP / 2.0 / UDP 192.168.1.2:5060; received = 80.230.219.70; rport = 5060; branch = z9hG4bKnp85213694 - 430aa1de192.168.1.2
Content - Length: 0";

            Response Parsed = Response.Parse(TestLine);

        }
    }
}
