using GeneSIPs.Header;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Server Server { get; set; }


        public static Response Parse(string Input)
        {
            Response r = new Response();

            string[] Lines = Input.Split(Environment.NewLine);

            foreach(string line in Lines)
            {
                if (line.Contains("SIP/"))
                {
                    //This is the Response Line
                    string[] LinePieces = line.Split(" ");
                    int PieceCount = LinePieces.Length;
                    int MessageStart = 2;
                    int Collected = 0;
                    List<string> MessagePieceList = new List<string>();
                    r.SIPVersion = LinePieces[0];
                    r.ResponseCode = int.Parse(LinePieces[1]);

                    while(Collected < (PieceCount - MessageStart))
                    {
                        int index = Collected  + MessageStart;
                        MessagePieceList.Add(LinePieces[index]);

                        Collected++;
                    }

                    r.ResponseMessage = string.Join(" ", MessagePieceList);
                }
            }


            return r;
        }
    }
}
