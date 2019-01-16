using GeneSIPs.Request;
using System;
using Xunit;

namespace GeneTests
{
    public class DatagramGeneration
    {
        [Fact]
        public void VerifyDatagramGeneration()
        {
            RequestUser user = new RequestUser()
            {
                HostPart = "sometelco.biz",
                UserPart = "7047509099"
            };

            RequestLine RequestLine = new RequestLine()
            {
                Method = RequestLine.MethodTypes.INVITE,
                RequestURI = user,
            };

            string Output = RequestLine.ToString();

            Assert.True(true);
        }
    }
}
