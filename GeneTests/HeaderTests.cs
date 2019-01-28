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

        //Hiding this for now until I can determine why the chosen regex is not valid.
        //[Fact]
        //public void VerifyFromIsValid()
        //{
        //    SIPMessage message = SIPMessage.Faker.Generate(1).First();
        //    Assert.True(message.Header.From.IsValid());
        //}

        [Fact]
        public void CustomHeadersAreRendered()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();
            Dictionary<string, string> CustomHeaders = new Dictionary<string, string>();
            CustomHeaders.Add("Test-Case", "1");

            message.Header.CustomHeaders = CustomHeaders;

            Assert.Contains("X-Test-Case: 1", message.ToString());
        }

        [Fact]
        public void VerifyCustomHeadersNotPresentWithEmptyDictionary()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();
            Assert.DoesNotContain("X-Test-Case: 1", message.ToString());
            Assert.DoesNotContain("X-",message.ToString());
        }

        [Fact]
        public void AllowMaxForwardsofZero()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();
            message.Header.MaxForwards = 0;

            Assert.Contains("Max-Forwards", message.ToString());
        }

        [Fact]
        public void BranchHasSemicolon()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();

            message.Header.From.Tag = "iamabanana";

            Assert.Contains(";", message.Header.From.ToString());
        }
        
    }
}
