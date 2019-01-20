using GeneSIPs.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using System.Linq;

namespace GeneSIPs.Header
{
    public class MessageHeader
    {
        public Via Via { get; set; }
        public From From { get; set; }
        public SipAddress To { get; set; }
        public CallId CallId { get; set; }
        public CSeq CSeq { get; set; }
        public string UserAgent { get; set; }
        public int Expires { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        //Contact will be generated based on the components of the From
        public int MaxForwards { get; set; }
        public List<Request.RequestLine.MethodTypes> Allow { get; set; }

        public static Faker<MessageHeader> Faker { get; set; } = new Faker<MessageHeader>()
            .StrictMode(false)
            .RuleFor(o => o.Accept, f => "application/sdp")
            .RuleFor(o => o.Allow, f => new List<Request.RequestLine.MethodTypes>()
                    {
                        {Request.RequestLine.MethodTypes.INVITE  },
                        {Request.RequestLine.MethodTypes.ACK  },
                        {Request.RequestLine.MethodTypes.CANCEL  },
                        {Request.RequestLine.MethodTypes.BYE  },
                        {Request.RequestLine.MethodTypes.REFER  },
                        {Request.RequestLine.MethodTypes.OPTIONS  },
                        {Request.RequestLine.MethodTypes.INFO  }
                    })
            .RuleFor(o => o.CallId, f => CallId.Faker.Generate(1).First())
            //.RuleFor(o => o.ContentLength, f => ) //TODO: Need to actually calculate the size of the body lol
            .RuleFor(o => o.ContentType, f => "application/sdp")
            .RuleFor(o => o.CSeq, f => CSeq.Faker.Generate(1).First())
            .RuleFor(o => o.Expires, f => f.Random.Int(5,25))
            .RuleFor(o => o.From, f => From.Faker.Generate(1).First())
            .RuleFor(o => o.MaxForwards, f => f.Random.Int(1,35))
            .RuleFor(o => o.To, f => SipAddress.Faker.Generate(1).First())
            .RuleFor(o => o.UserAgent , f => f.Internet.UserAgent())
            .RuleFor(o => o.Via, f => Via.Faker.Generate(1).First())
            ;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Via.ToString());
            sb.Append(From.ToString());
            sb.Append($"To: <sip:{To.ToString()}>").AppendLine();
            sb.Append(CallId.ToString());
            sb.Append(CSeq.ToString());
            if(!string.IsNullOrEmpty(UserAgent)) sb.Append($"User-Agent: {UserAgent}").AppendLine();
            if(Expires > 0 ) sb.Append($"Expires: {Expires.ToString()}").AppendLine();
            if(!string.IsNullOrEmpty(Accept)) sb.Append($"Accept: {Accept}").AppendLine();
            if(!string.IsNullOrEmpty(ContentType)) sb.Append($"Content-Type: {ContentType}").AppendLine();
            if(ContentLength > 0 ) sb.Append($"Content-Length: {ContentLength.ToString()}").AppendLine();
            if (MaxForwards > 0) sb.Append($"Max-Forwards: {MaxForwards}").AppendLine();
            if (Allow != null && Allow.Count > 0) sb.Append($"Allow: {string.Join(",",Allow)}").AppendLine();

            return sb.ToString();   
        }
    }
}
