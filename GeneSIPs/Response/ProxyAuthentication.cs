using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneSIPs.Response
{
    public class ProxyAuthentication
    {
        public string DigestRealm { get; set; }
        public string Nonce { get; set; }
        public string Opaque { get; set; }
        public bool Stale { get; set; }
        public string Algorithm { get; set; }

        public static ProxyAuthentication Parse(string Input)
        {
            ProxyAuthentication pa = new ProxyAuthentication();
            string[] ProxyPieces = Input.Split(",");

            if(ProxyPieces.Length != 5)
            {
                throw new IndexOutOfRangeException("Not enough components to message. Validate sent response");
            }

            pa.DigestRealm = ProxyPieces[0].Split("=").Last().Replace("\"", "");
            pa.Nonce = ProxyPieces[1].Split("=").Last().Replace("\"", "");
            pa.Opaque = ProxyPieces[2].Split("=").Last().Replace("\"", "");
            pa.Stale = bool.Parse(ProxyPieces[3].Split("=").Last().Replace("\"", ""));
            pa.Algorithm = ProxyPieces[4].Split("=").Last().Replace("\"", "");

            return pa;
        }
    }
}
