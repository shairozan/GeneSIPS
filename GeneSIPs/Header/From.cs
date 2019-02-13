using GeneSIPs.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneSIPs.Header
{
    public class From
    {
        /// <summary>
        /// Also known as the "Friendly Name" in SMTP structures
        /// </summary>
        public string DisplayName { get; set; }
        public SipAddress User { get; set; }
        public string Tag { get; set; } //Required per RFC 3261 Section 19.3
        // ^From: \"[a-zA-Z -_]{1,}\" <[a-zA-z0-9._]{1,}@[a-zA-Z0-9._]{1,}>(?:tag=[a-z0-9]{1,8})?$ is raw regex
        private Regex Validity = new Regex(@"^From: .[a-zA-Z-_]{1,}. <[a-zA-z0-9._]{1,}@[a-zA-Z0-9._]{1,}>(?:tag=[a-z0-9]{1,8})?$\r\n");
        

        public bool IsValid()
        {
            string From = this.ToString();
            return Validity.IsMatch(From);
        }

        public static Faker<From> Faker { get; set; } = new Faker<From>()
            .StrictMode(false)
            .RuleFor(o => o.DisplayName, f => f.Name.FullName())
            .RuleFor(o => o.User, f => SipAddress.Faker.Generate(1).First())
            .RuleFor(o => o.Tag, f => Guid.NewGuid().ToString());

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"From: \"{DisplayName}\" ");
            sb.Append($"<sip:{User.ToString()}>");

            if(!string.IsNullOrWhiteSpace(Tag))
            {
                sb.Append($";tag={Tag}");
            }

            sb.AppendLine();

            return sb.ToString();
        }

        public static From Parse(string Input)
        {
            From f = new From();
            string[] FirstPiece = Input.Split(" ");
            f.DisplayName = FirstPiece[1].Replace("\"","");

            string[] SecondPieces = FirstPiece[2].Split("<");
            f.User = new SipAddress();
            f.User.User = SecondPieces[1].Split(":")[1].Split(">")[0].Split("@")[0];
            f.User.Domain = SecondPieces[1].Split(":")[1].Split(">")[0].Split("@")[1];

            if (Input.Contains("tag"))
            {
                f.Tag = Input.Split(";").Last().Split("=").Last();
            }

            return f;
        }
    }
}
