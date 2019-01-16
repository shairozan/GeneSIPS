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
