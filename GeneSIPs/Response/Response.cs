using GeneSIPs.Header;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneSIPs.Response
{
    public class Response
    {
        string SIPVersion { get; set; } = "SIP/2.0";
        int ResponseCode { get; set; }
        string ResponseMessage { get; set; }
        List<string> AllowedMethods { get; set; }
        string CallID { get; set; }
        CSeq Cseq { get; set; }
        From From { get; set; }


    }
}
