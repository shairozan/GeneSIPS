using GeneSIPs.Body;
using GeneSIPs.Header;
using GeneSIPs.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using System.Linq;

namespace GeneSIPs
{
    public class SIPMessage
    {

        public SIPMessage()
        {

        }

        public SIPMessage(Faker<SIPMessage> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public static void SetCustomFaker(Faker<SIPMessage> fakzor)
        {
            Faker = fakzor;
        }

        //Contains the Request URI Etc
        public RequestLine RequestLine { get; set; }
        public MessageHeader Header { get; set; }
        public MessageBody Body { get; set; }
        public static Faker<SIPMessage> Faker { get; set; } = new Faker<SIPMessage>()
            .StrictMode(false)
            .RuleFor(o => o.RequestLine, f => RequestLine.Faker.Generate(1).First())
            .RuleFor(o => o.Header, f => MessageHeader.Faker.Generate(1).First())
            .RuleFor(o => o.Body, f => MessageBody.Faker.Generate(1).First())
            .FinishWith( (f,u) =>
            {
                if(!string.IsNullOrEmpty(u.Body.ToString()))
                {
                    u.Header.ContentLength = Encoding.UTF8.GetBytes(u.Body.ToString()).Length;
                }
            });
  


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(RequestLine.ToString());
            sb.Append(Header.ToString());
            sb.AppendLine();
            if(Body != null)
            {
                sb.Append(Body.ToString());
            }
            

            return sb.ToString();
        }

    }
}
