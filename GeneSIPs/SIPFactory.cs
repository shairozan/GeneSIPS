using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Bogus;
using GeneSIPs.Common;
using GeneSIPs.Header;
using GeneSIPs.Request;
using System.Linq;

namespace GeneSIPs
{
    public class SIPFactory
    {
        public enum MessageTypes
        {
            INVITE,
            BYE,
            ACK,
            OPTIONS,
            INFO,
        }

        private MessageTypes MessageType { get; set; }
        private Faker<SIPMessage> MessageFaker { get; set; }

        public SIPFactory(MessageTypes Type)
        {
            MessageType = Type;
        }

        public SIPMessage Generate(int Quantity = 1)
        {
            switch (MessageType)
            {
                case MessageTypes.INVITE:
                    Faker<RequestUser> RURIUser = new Faker<RequestUser>()
                .StrictMode(false)
                .RuleFor(o => o.UserPart, f => f.Phone.PhoneNumber("##########"))
                .RuleFor(o => o.HostPart, f => f.Internet.DomainName());

                    //Create Faker for Request
                    Faker<RequestLine> RURIFaker = new Faker<RequestLine>()
                        .StrictMode(false)
                        .RuleFor(o => o.Method, f => RequestLine.MethodTypes.INVITE)
                        .RuleFor(o => o.RequestURI, RURIUser)
                        .RuleFor(o => o.SIPVersion, f => "SIP/2.0");

                    Faker<MessageHeader> HeaderFaker = new Faker<MessageHeader>()
                        .StrictMode(false)
                        .RuleFor(o => o.Via, f => new Faker<Via>()
                            .StrictMode(false)
                            .RuleFor(p => p.SIPVersion, g => "SIP/2.0")
                            .RuleFor(p => p.SentBy, g => new Faker<SipUser>().StrictMode(false)
                                .RuleFor(q => q.Address, h => IPAddress.Parse(h.Internet.Ip()))
                                .RuleFor(q => q.Port, h => 5060))
                            .RuleFor(p => p.Branch, g => "z9hG4bK")//Magic Cookie referred to in IETF Doc
                            .RuleFor(p => p.RPort, g => "rport")
                            ) 
                        .RuleFor(o => o.MaxForwards, f => 9)
                        .RuleFor(o => o.From, new Faker<From>().StrictMode(false)
                            .RuleFor(p => p.DisplayName, f => f.Name.FirstName())
                            .RuleFor(p => p.User, new Faker<SipAddress>()
                                .StrictMode(false)
                                .RuleFor(q => q.User, f => f.Internet.UserName())
                                .RuleFor(q => q.Domain, f => f.Internet.DomainName())
                                )
                            )
                        .RuleFor(o => o.To, new Faker<SipAddress>()
                                .StrictMode(false)
                                .RuleFor(q => q.User, f => f.Internet.UserName())
                                .RuleFor(q => q.Domain, f => f.Internet.DomainName()
                            )
                        )
                        .RuleFor(o => o.CallId, new Faker<CallId>()
                            .StrictMode(false)
                            .RuleFor(p => p.Identifier, f => f.Random.String2(10))
                            .RuleFor(p => p.Host, f => IPAddress.Parse(f.Internet.Ip()))
                            )
                        .RuleFor(o => o.CSeq, new Faker<CSeq>()
                                .StrictMode(false)
                                .RuleFor(p => p.Method, f => RequestLine.MethodTypes.INVITE)
                                .RuleFor(p => p.Sequence, f => 1)
                            )
                        ;

                    MessageFaker = new Faker<SIPMessage>()
                        .StrictMode(false)
                        .RuleFor(o => o.RequestLine, RURIFaker)
                        .RuleFor(o => o.Header, HeaderFaker)
                        .RuleFor(o => o.Body, f => null);
                    break;


            }
            SIPMessage message = new SIPMessage();

            

            SIPMessage.SetCustomFaker(MessageFaker);

            return SIPMessage.Faker.Generate(Quantity).First();
        }
    }
}
