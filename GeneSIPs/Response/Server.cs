using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GeneSIPs.Response
{
    public class Server
    {
        public string Name { get; set; }
        public string VersionIdentifier { get; set; }
        public string Type { get; set; }

        public static Server Parse(string Input)
        {
            Server s = new Server();
            string[] pieces = Input.Split(" ");

            if(pieces.Length != 3)
            {
                throw new IndexOutOfRangeException("Message does not appear complete");
            }

            s.Name = pieces[1].Split("/").First();
            s.VersionIdentifier = pieces[1].Split("/").Last();
            s.Type = pieces[2].Replace(")", "").Replace("(", "");

            return s;
        }
    }
}
