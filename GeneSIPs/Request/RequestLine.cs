using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Request
{
    public class RequestLine
    {

        public enum MethodTypes
        {
            INVITE,
            ACK,
            CANCEL,
            BYE,
            REFER,
            OPTIONS,
            NOTIFY,
            INFO
        };

        public MethodTypes Method { get; set; }
        public RequestUser RequestURI { get; set; }
        public string SIPVersion { get; set; } = "SIP/2.0";

        public override string ToString()
        {
            return $"{Method.ToString().ToUpper()} {RequestURI.ToString()} {SIPVersion}";
        }
    }
}
