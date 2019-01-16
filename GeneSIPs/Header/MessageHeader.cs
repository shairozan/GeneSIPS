using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Header
{
    public class MessageHeader
    {
        public Via Via { get; set; }
        public From From { get; set; }
        public To To { get; set; }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Via.ToString());
            sb.Append(From.ToString());
            sb.Append(To.ToString());
            sb.Append(CallId.ToString());
            sb.Append(CSeq.ToString());
            if(!string.IsNullOrEmpty(UserAgent)) sb.Append($"User-Agent: {UserAgent}").AppendLine();
            if(Expires > 0 ) sb.Append($"Expires: {Expires.ToString()}").AppendLine();
            if(!string.IsNullOrEmpty(Accept)) sb.Append($"Accept: {Accept}").AppendLine();
            if(!string.IsNullOrEmpty(ContentType)) sb.Append($"Content-Type: {ContentType}").AppendLine();
            if(ContentLength > 0 ) sb.Append($"Content-Length: {ContentLength.ToString()}").AppendLine();
            if (MaxForwards > 0) sb.Append($"Max Forwards: {MaxForwards}").AppendLine();
            if (Allow != null && Allow.Count > 0) sb.Append($"Allow: {string.Join(",",Allow)}").AppendLine();

            return sb.ToString();   
        }
    }
}
