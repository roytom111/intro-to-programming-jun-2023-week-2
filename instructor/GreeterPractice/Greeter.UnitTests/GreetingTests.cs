

using Moq;

namespace Greeter.UnitTests;
public class GreetingTests
{
    private readonly GreetingMaker greeter;
    public GreetingTests()
    {
        var dummyBannedNameService = new Mock<IProvideBannedNames>();
        dummyBannedNameService.Setup(d => d.GetListOfBannedNames()).Returns(new List<string>());

        greeter = new GreetingMaker(dummyBannedNameService.Object, new Mock<INotifyOfTrolls>().Object);
    }
    [Theory]
    [InlineData("Windom", "Hello, Windom!")]
    [InlineData("Cooper", "Hello, Cooper!")]
    [InlineData("Gordon", "Hello, Gordon!")]
    public void SingleName(string name, string expected)
    {

        string greeting = greeter.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("WINDOM", "HELLO, WINDOM!")]
    [InlineData("Cooper", "Hello, Cooper!")]
    [InlineData("GORDON", "HELLO, GORDON!")]
    public void Shouting(string name, string expected)
    {
        string greeting = greeter.Greet(name);

        Assert.Equal(expected, greeting);
    }
    [Theory]
    [InlineData("Windom", "Gordon", "Hello, Windom, and Gordon!")]
    [InlineData("Cooper", "Truman", "Hello, Cooper, and Truman!")]
    [InlineData("Cooper", "Hawk", "Hello, Cooper, and Hawk!")]

    public void TwoNames(string name1, string name2, string expected)
    {
        string greeting = greeter.Greet(name1, name2);

        Assert.Equal(expected, greeting);
    }

    [Fact]

    public void ArbitraryListOfNamesExample1()
    {

        string greeting = greeter.Greet("Cole", "Cooper", "Rosenfield", "Preston", "Milford", "Jeffries");

        Assert.Equal("Hello, Cole, Cooper, Rosenfield, Preston, Milford, and Jeffries!", greeting);
    }

    [Fact]
    public void ArbitraryListOfNamesExample2()
    {

        string greeting = greeter.Greet("Ian", "Guy", "Brendan", "Joe");

        Assert.Equal("Hello, Ian, Guy, Brendan, and Joe!", greeting);
    }

    [Fact(Skip ="Remove this from the practice.")]
    public void HandlesNulls()
    {
        //var greeting = greeter.Greet(null);

        //Assert.Equal("Hello, Chief!", greeting);
    }
    [Fact]
    public void ArbitraryListOfNamesAllShouted()
    {

        string greeting = greeter.Greet("IAN", "GUY", "BRENDAN", "JOE");

        Assert.Equal("HELLO, IAN, GUY, BRENDAN, AND JOE!", greeting);
    }

    [Fact]
    public void MixedShoutingExample1()
    {
        string greeting = greeter.Greet("Ian", "GUY", "Brendan", "JOE");

        Assert.Equal("Hello, Ian, Brendan, AND GUY, JOE!", greeting);
    }

    [Fact]
    public void MixedShoutingExample2()
    {
        string greeting = greeter.Greet("Ian", "GUY");

        Assert.Equal("Hello, Ian, AND GUY!", greeting);
    }

    [Fact(Skip = "Remove from Practice - but what if an empty string?")]
    public void NullsInListOfNames()
    {


        //string greeting = greeter.Greet("Ian", null, "Bill");

        //Assert.Equal("Hello, Ian, Chief!, and, Bill!", greeting);

        //string greetin2 = greeter.Greet("Ian", null, "Bill", null, "Sue");

    }
}
