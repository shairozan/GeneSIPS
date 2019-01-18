using GeneSIPs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace GeneTests
{
    public class HeaderTests
    {
        [Fact]
        public void VerifyFromIsValid()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();
            Assert.True(message.Header.From.IsValid());
        }
        
    }
}
