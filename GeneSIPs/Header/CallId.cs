using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GeneSIPs.Header
{
    public class CallId
    {
        /// <summary>
        /// Not sure if this is some kind of unique ID. Will use GUID in testing
        /// </summary>
        public string Identifier { get; set; }
        public IPAddress Host { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Call-ID: ");
            sb.Append($"{Identifier}@{Host.ToString()}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
