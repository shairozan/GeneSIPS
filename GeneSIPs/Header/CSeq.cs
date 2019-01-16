using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Header
{
    public class CSeq
    {
        public int Sequence { get; set; }
        public Request.RequestLine.MethodTypes Method { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CSeq: {Sequence} {Method.ToString()}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
