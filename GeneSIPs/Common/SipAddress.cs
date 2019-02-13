using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace GeneSIPs.Common
{
    public class SipAddress
    {
        public string User { get; set; }
        public string Domain { get; set; }
        //TODO: RFC 3261 Section 19.3 Indicates that both the To and From header fields should have a tag value
        //But no samples I've seen actually have them. Even in the RFC. Only From Tags have them in their value.
        public static Faker<SipAddress> Faker { get; set; } = new Faker<SipAddress>()
            .StrictMode(true)
            .RuleFor(o => o.User, f => f.Internet.Email().Split('@')[0])
            .RuleFor(o => o.Domain, f => f.Internet.Email().Split('@')[1]);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{User}@{Domain}");
            return sb.ToString();
        }
    }
}
