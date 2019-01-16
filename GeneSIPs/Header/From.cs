using GeneSIPs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Header
{
    public class From
    {
        /// <summary>
        /// Also known as the "Friendly Name" in SMTP structures
        /// </summary>
        public string DisplayName { get; set; }
        public SipUser User { get; set; }
        public string Tag { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"From: {sb.Append(DisplayName)} ");
            sb.Append($"<{User.ToString()}>");

            if(!string.IsNullOrWhiteSpace(Tag))
            {
                sb.Append($"tag={Tag}");
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
