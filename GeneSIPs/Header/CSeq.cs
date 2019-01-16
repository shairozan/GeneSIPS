﻿using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace GeneSIPs.Header
{
    public class CSeq
    {
        public CSeq()
        {

        }

        public CSeq(Faker<CSeq> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public int Sequence { get; set; }
        public Request.RequestLine.MethodTypes Method { get; set; }
        public static Faker<CSeq> Faker { get; set; } = new Faker<CSeq>()
            .StrictMode(false)
            .RuleFor(o => o.Sequence, f => f.Random.Int())
            .RuleFor(o => o.Method, f => f.PickRandom<Request.RequestLine.MethodTypes>());

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CSeq: {Sequence} {Method.ToString()}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
