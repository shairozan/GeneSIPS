using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using System.Linq;

namespace GeneSIPs.Request
{
    public class RequestLine
    {

        public RequestLine()
        {

        }

        public RequestLine(Faker<RequestLine> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public enum MethodTypes
        {
            INVITE,
            ACK,
            CANCEL,
            BYE,
            REFER,
            OPTIONS,
            NOTIFY,
            INFO
        };

        public MethodTypes Method { get; set; }
        public RequestUser RequestURI { get; set; }
        public string SIPVersion { get; set; } = "SIP/2.0";
        public static Faker<RequestLine> Faker = new Faker<RequestLine>()
            .StrictMode(false)
            .RuleFor(o => o.Method, f => MethodTypes.INVITE)
            .RuleFor(o => o.RequestURI, f => RequestUser.Faker.Generate(1).First())
            .RuleFor(o => o.SIPVersion, f => "SIP/2.0");

        public override string ToString()
        {
            return $"{Method.ToString().ToUpper()} {RequestURI.ToString()} {SIPVersion}\n";
        }
    }
}
