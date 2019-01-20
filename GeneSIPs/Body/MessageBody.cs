using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using System.Linq;

namespace GeneSIPs.Body
{
    public class MessageBody
    {
        /// <summary>
        /// (v)
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// (o)
        /// </summary>
        public Owner Owner { get; set; }
        /// <summary>
        /// (s)
        /// </summary>
        public string SessionName { get; set; }
        /// <summary>
        /// (c)
        /// </summary>
        public ConnectionInformation ConnectionInformation { get; set; }
        /// <summary>
        /// (t)
        /// </summary>
        public Time Time { get; set; }
        /// <summary>
        /// (m)
        /// </summary>
        public MediaDescription MediaDescription { get; set; }
        /// <summary>
        /// [](a)
        /// </summary>
        public List<MediaAttribute> MediaAttributes { get; set; }
        public static Faker<MessageBody> Faker { get; set; } = new Faker<MessageBody>()
            .StrictMode(false)
            .RuleFor(o => o.Version, f => f.Random.Int())
            .RuleFor(o => o.Owner, f => Owner.Faker.Generate(1).First())
            .RuleFor(o => o.SessionName, f => "SIP call")
            .RuleFor(o => o.ConnectionInformation, f => ConnectionInformation.Faker.Generate(1).First())
            .RuleFor(o => o.Time, f => Time.Faker.Generate(1).First())
            .RuleFor(o => o.MediaDescription, f => MediaDescription.Faker.Generate(1).First())
            .RuleFor(o => o.MediaAttributes, f => new List<MediaAttribute>()
            {
                MediaAttribute.Faker.Generate(1).First()
            });


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"v={Version.ToString()}").Append("\n");
            sb.Append(Owner.ToString());
            sb.Append($"s={SessionName}").Append("\n");
            sb.Append(ConnectionInformation.ToString());
            sb.Append(Time.ToString());
            sb.Append(MediaDescription.ToString());

            foreach(MediaAttribute m in MediaAttributes)
            {
                sb.Append(m.ToString());
            }

            //Lastly Append the weird custom one
            sb.Append("a=sendrecv").Append("\n");
            return sb.ToString();
        }
    }
}
