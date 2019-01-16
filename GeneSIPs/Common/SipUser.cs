using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bogus;

namespace GeneSIPs.Common
{
    public class SipUser
    {
        public SipUser()
        {

        }

        /// <summary>
        /// Allows for the passage of a custom Faker 
        /// to allow for custom rules generation
        /// </summary>
        /// <param name="CustomFaker"></param>
        public SipUser(Faker<SipUser> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public IPAddress Address { get; set; }
        public int Port { get; set; }
        public static Faker<SipUser> Faker { get; set; }  = new Faker<SipUser>()
            .StrictMode(true)
            .RuleFor(o => o.Address, f => IPAddress.Parse(f.Internet.Ip()))
            .RuleFor(o => o.Port, f => f.Random.Number(9000))
            ;

        public override string ToString()
        {
            return $"{Address.ToString()}:{Port}";
        }
    }
}
