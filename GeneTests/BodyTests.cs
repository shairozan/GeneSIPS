using GeneSIPs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Bogus;
using GeneSIPs.Request;
using GeneSIPs.Header;

namespace GeneTests
{
    public class BodyTests
    {
        [Fact]
        public void ContentLengthSetTest()
        {
            SIPMessage testmessage = SIPMessage.Faker.Generate(1).First();

            if(testmessage.Body != null)
            {
                Assert.True(testmessage.Header.ContentLength > 0);
                Assert.True(testmessage.Header.ContentLength == Encoding.UTF8.GetByteCount(testmessage.Body.ToString()));
            } else
            {
                Assert.True(testmessage.Header.ContentLength == 0);
            }

            
            
        }

        [Fact]
        public void VerifyNoContentLengthIfBodyNotPresent()
        {
            Faker<SIPMessage> CustomFaker = new Faker<SIPMessage>()
                .StrictMode(false)
                .RuleFor(o => o.Body, f => null)
                .RuleFor(o => o.RequestLine, f => RequestLine.Faker.Generate(1).First())
                .RuleFor(o => o.Header, f => MessageHeader.Faker.Generate(1).First());

            SIPMessage.SetCustomFaker(CustomFaker);

            Assert.Equal(CustomFaker, SIPMessage.Faker);

            SIPMessage TestMessage = SIPMessage.Faker.Generate(1).First();
            Assert.Null(TestMessage.Body);
            Assert.DoesNotContain("Content-Length", TestMessage.ToString());
      
        }
    }
}
