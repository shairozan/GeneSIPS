using GeneSIPs;
using GeneSIPs.Request;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace GeneTests
{
    public class DatagramGeneration
    {
        [Fact]
        public void VerifyDatagramGeneration()
        {
            List<SIPMessage> Messages = new List<SIPMessage>();
            Messages.AddRange(SIPMessage.Faker.Generate(50));

            Assert.NotEmpty(Messages);
        }
    }
}
