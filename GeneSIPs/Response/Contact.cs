using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GeneSIPs.Response
{
    public class Contact
    {
        public string Protocol { get; set; } = "sip";
        public string Address { get; set; }
        public int Port { get; set; }

        public static Contact Parse(string input)
        {
            Contact c = new Contact();
            string pieces = input.Split("<").ElementAt(1).Replace(">","");
            string[] components = pieces.Split(":");

            if(components.Length != 3)
            {
                throw new IndexOutOfRangeException("Line does not contain required components");
            }

            c.Protocol = components[0];
            c.Address = components[1];
            c.Port = int.Parse(components[2]);

            return c;
        }
    }
}
