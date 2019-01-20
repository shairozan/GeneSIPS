using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bogus;

namespace GeneSIPs.Header
{
    public class CallId
    {
        /// <summary>
        /// Not sure if this is some kind of unique ID. Will use GUID in testing
        /// </summary>
        public string Identifier { get; set; }
        public IPAddress Host { get; set; }

        public CallId()
        {

        }

        public CallId(Faker<CallId> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public static Faker<CallId> Faker { get; set; } = new Faker<CallId>()
            .StrictMode(false)
            .RuleFor(o => o.Identifier, f => f.Random.String2(10, "abcdefghijklmnopqrstuvwxy0123456789"))
            .RuleFor(o => o.Host, f => IPAddress.Parse(f.Internet.Ip()));


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Call-ID: ");
            sb.Append($"{Identifier}@{Host.ToString()}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
