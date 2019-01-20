using System;
using System.Collections.Generic;
using System.Text;
using Bogus; 

namespace GeneSIPs.Request
{
    public class RequestUser
    {
        public RequestUser()
        {

        }

        public RequestUser(Faker<RequestUser> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public string UserPart { get; set; }
        public string HostPart { get; set; }
        public static Faker<RequestUser> Faker { get; set; } = new Faker<RequestUser>()
            .StrictMode(false)
            .RuleFor(o => o.UserPart, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(o => o.HostPart, f => f.Internet.DomainName());

        public override string ToString()
        {
            return $"sip:{UserPart}@{HostPart}";
        }
    }
}
