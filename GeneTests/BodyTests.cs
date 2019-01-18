using GeneSIPs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace GeneTests
{
    public class BodyTests
    {
        [Fact]
        public void ContentLengthSetTest()
        {
            SIPMessage testmessage = SIPMessage.Faker.Generate(1).First();

            Assert.True(testmessage.Header.ContentLength > 0);
            Assert.True(testmessage.Header.ContentLength == Encoding.UTF8.GetByteCount(testmessage.Body.ToString()));
        }
    }
}
