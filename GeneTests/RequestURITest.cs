using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using GeneSIPs;
using System.Text.RegularExpressions;

namespace GeneTests
{
    public class RequestURITest
    {
        /// <summary>
        /// This is only against default rules. You can create your own rules to break things lol
        /// </summary>
        [Fact]
        public void EnsureValidPhoneFromFaker()
        {
            SIPMessage message = SIPMessage.Faker.Generate(1).First();
            Assert.NotNull(message.RequestLine.RequestURI.UserPart);
            //https://stackoverflow.com/questions/2113908/what-regular-expression-will-match-valid-international-phone-numbers : Updated to make the international identifiers optional
            Regex PhoneRegex = new Regex(@"^\+?(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)?\d{1,14}$");

            Assert.Matches(PhoneRegex, message.RequestLine.RequestURI.UserPart);
        }
    }
}
