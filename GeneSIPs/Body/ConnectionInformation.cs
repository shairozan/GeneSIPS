using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bogus;

namespace GeneSIPs.Body
{
    public class ConnectionInformation
    {
        public ConnectionInformation()
        {

        }

        public ConnectionInformation(Faker<ConnectionInformation> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public string NetworkType { get; set; } = "IN";
        public string AddressType { get; set; } = "IPV4";
        public IPAddress Address { get; set; }
        public static Faker<ConnectionInformation> Faker { get; set; } = new Faker<ConnectionInformation>()
            .StrictMode(false)
            .RuleFor(o => o.NetworkType, f => "IN")
            .RuleFor(o => o.AddressType, f => "IPV4")
            .RuleFor(o => o.Address, f => IPAddress.Parse(f.Internet.Ip()));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"c={NetworkType} {AddressType} {Address.ToString()}\n");
            return sb.ToString();
        }
    }
}
