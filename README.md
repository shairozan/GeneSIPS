# GeneSIPS
GeneSIPS is a simplistic library for bulk generation of SIPs datagrams.

## Methodology
Since SIP Datagrams are really just text structures following IETF documents https://tools.ietf.org/html/rfc3261 and https://tools.ietf.org/html/rfc2046, 
the primary goal of this library is to build the structure of the message in string format such that it can be encoded
and piped into a UDP Client. 

## Generation
Each class and its subclass will contain a public faker object. While the library has "general" rules defined, you can also build your own Faker<T> objects
and pass them to each class as a constructor to override the default value. 

## Testing
Each class (Or Line in the message) will contain its own Regex value to test for validity. As such you can bulk generate data, and then validate each line (and then the entire message)
against the regex. 

## Usage

The first case is just generating a datagram:

```c#
 SIPMessage TestMessage = SIPMessage.Faker.Generate(1).First();
```

This will provide you an actual Datagram object. If you want the raw datagram converted to test, you can just call `ToString()` on the object:

```c#
string Datagram = TestMessage.ToString()
```

### Custom Fakers
I'm in the process of implementing static faker settings across all objects, but let's look at the SIPMessage object. The below allows you to create a custom Faker for the entire object that, in this case, leaves the Body null:

```c#
Faker<SIPMessage> CustomFaker = new Faker<SIPMessage>()
                .StrictMode(false)
                .RuleFor(o => o.Body, f => null)
                .RuleFor(o => o.RequestLine, f => RequestLine.Faker.Generate(1).First())
                .RuleFor(o => o.Header, f => MessageHeader.Faker.Generate(1).First());

SIPMessage.SetCustomFaker(CustomFaker);
SIPMessage TestMessage = SIPMessage.Faker.Generate(1).First();           
```

### Bulk Generation
If you're looking at bulk-generating datagrams, you will do it via `Faker.Generate(x)`. As a heads up, initial benchmarking was able to produce 50,000 in 2.2 seconds. Can probably be tuned down, but should also be implemented in parallel if you need large volumes. 
