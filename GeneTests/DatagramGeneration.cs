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

        /// <summary>
        /// When looking into wireshark dumps, the codes use hex falue 0a
        /// which apparently just correlates to new line (\n)
        /// </summary>
        [Fact]
        public void VerifyNoCarriageReturns()
        {
            SIPMessage Message = SIPMessage.Faker.Generate(1).First();
            string MessageString = Message.ToString();
           
            Assert.DoesNotContain("\r", MessageString);
        }
    }
}
