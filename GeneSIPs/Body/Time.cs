using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace GeneSIPs.Body
{
    public class Time
    {
        public Time()
        {

        }

        public Time(Faker<Time> CustomFaker)
        {
            Faker = CustomFaker;
        }

        public int StartTime { get; set; } = 0;
        public int StopTime { get; set; } = 0;
        public static Faker<Time> Faker { get; set; } = new Faker<Time>()
            .StrictMode(false)
            .RuleFor(o => o.StartTime, f => f.Random.Int(0, 10))
            .RuleFor(o => o.StopTime, f => f.Random.Int(20, 45));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"t={StartTime} {StopTime}");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
