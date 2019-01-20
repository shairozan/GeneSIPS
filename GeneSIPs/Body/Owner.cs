using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bogus;

namespace GeneSIPs.Body
{
    public class Owner
    {

        public Owner()
        {

        }

        public Owner(Faker<Owner> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public string Username { get; set; }
        public string SessionId { get; set; }
        public string SessionVersion { get; set; }
        public string NetworkType { get; set; }
        public string AddressType { get; set; }
        public IPAddress OwnerAddress { get; set; }
        public static Faker<Owner> Faker { get; set; } = new Faker<Owner>()
            .StrictMode(false)
            .RuleFor(o => o.Username, f => f.Internet.UserName())
            .RuleFor(o => o.SessionId, f => f.Random.Guid().ToString()) //TODO: Not sure if GUID is a good option
            .RuleFor(o => o.SessionVersion, f => f.Random.Guid().ToString())
            .RuleFor(o => o.NetworkType, f => "IN")
            .RuleFor(o => o.AddressType, f => "IPV4")
            .RuleFor(o => o.OwnerAddress, f => IPAddress.Parse(f.Internet.Ip()));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("o=");
            sb.Append($"{Username} ");
            sb.Append($"{SessionId} ");
            sb.Append($"{SessionVersion} ");
            sb.Append($"{NetworkType} ");
            sb.Append($"{AddressType} ");
            sb.Append($"{OwnerAddress.ToString()}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
