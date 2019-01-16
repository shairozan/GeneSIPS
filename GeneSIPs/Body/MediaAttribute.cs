using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace GeneSIPs.Body
{
    public class MediaAttribute
    {

        public MediaAttribute()
        {

        }

        public MediaAttribute(Faker<MediaAttribute> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public string MediaAttributeFieldName { get; set; } = "rtpmap";
        public int MediaFormat { get; set; } = 0;
        public string MIMEType { get; set; } = "pcmu";
        public int SampleRate { get; set; } = 8000;
        public static Faker<MediaAttribute> Faker { get; set; } = new Faker<MediaAttribute>()
            .StrictMode(false)
            .RuleFor(o => o.MediaAttributeFieldName, f => "rtpmap")
            .RuleFor(o => o.MediaFormat, f => 0)
            .RuleFor(o => o.MIMEType, f => "pcmu")
            .RuleFor(o => o.SampleRate, f => 8000);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"a={MediaAttributeFieldName}:{MediaFormat.ToString()} {MIMEType}/{SampleRate}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
