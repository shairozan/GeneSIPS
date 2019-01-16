using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;

namespace GeneSIPs.Body
{
    public class MediaDescription
    {

        public MediaDescription()
        {

        }

        public MediaDescription(Faker<MediaDescription> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public static Dictionary<int, string> MediaTypeMappings { get; set; } = new Dictionary<int, string>()
        {
            {0, "ITU-T G.711 PCMU" },
            {8, "ITU-T G.711 PCMA" },
            {97, "DynamicRTP-Type-97" },
            {2, "ITU-T G.721" },
            {3, "GSM 06.10" }
        };

        public string MediaType { get; set; } = "audio";
        public int Port { get; set; }
        public string MediaProtocol { get; set; } = "RTP/AVP";
        /// <summary>
        /// Correlates to keys int eh MediaTypeMappings list
        /// </summary>
        public List<int> MediaTypes { get; set; }
        public static Faker<MediaDescription> Faker { get; set; } = new Faker<MediaDescription>()
            .StrictMode(false)
            .RuleFor(o => o.MediaType, f => "audio")
            .RuleFor(o => o.Port, f => f.Random.Int(10000, 18000))
            .RuleFor(o => o.MediaProtocol, f => "RTP/AVP")
            .RuleFor(o => o.MediaTypes, f => new List<int>() { MediaTypeMappings.FirstOrDefault(x => x.Key == f.PickRandom<int>(MediaTypeMappings.Keys)).Key });

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"m={MediaType} {Port} {MediaProtocol} ");
            foreach(int MediaType in MediaTypes)
            {
                sb.Append($"{MediaType.ToString()} ");
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}
