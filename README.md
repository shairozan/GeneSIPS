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
