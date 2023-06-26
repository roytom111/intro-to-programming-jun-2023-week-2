

using Moq;

namespace Greeter.UnitTests;
public class GreeterInteractionTests
{
    private readonly Mock<INotifyOfTrolls> _trollNotifierMock;

    public GreeterInteractionTests()
    {
        _trollNotifierMock = new Mock<INotifyOfTrolls>();
    }

    [Fact]
    public void ItCallsTheServiceForBannedNames()
    {
        var mockedBannedNamesService = new Mock<IProvideBannedNames>();
        mockedBannedNamesService.Setup(b => b.GetListOfBannedNames()).Returns(new List<string>());

        var greeter = new GreetingMaker(mockedBannedNamesService.Object, _trollNotifierMock.Object);

        greeter.Greet("Han");

        mockedBannedNamesService.Verify(b => b.GetListOfBannedNames(), Times.Once());


    }

    [Theory]
    [InlineData("Jayden", "J****n")]
    [InlineData("Brian", "B***n")]
    public void ABannedNameIsElided(string name, string expected)
    {
        var mockedBannedNamesService = new Mock<IProvideBannedNames>();
        mockedBannedNamesService.Setup(b => b.GetListOfBannedNames()).Returns(new List<string>() { "Jayden", "Brian" });

        var greeter = new GreetingMaker(mockedBannedNamesService.Object, _trollNotifierMock.Object);

        var greeting = greeter.Greet(name);

        Assert.Contains(expected, greeting);
        Assert.DoesNotContain(name, greeting);
    }

    [Fact]
    public void ABannedNameIsElided2()
    {
        var mockedBannedNamesService = new Mock<IProvideBannedNames>();
        mockedBannedNamesService.Setup(b => b.GetListOfBannedNames()).Returns(new List<string>() { "Jeff", "Bill" });

        var greeter = new GreetingMaker(mockedBannedNamesService.Object, _trollNotifierMock.Object);

        var greeting = greeter.Greet("Stacey", "Jeff", "Henry", "Bill");

        Assert.Equal("Hello, Stacey, Henry, J**f, and B**l!", greeting);
    }

    [Fact]
    public void IfAllNamesAreBannedTheNotificationHappens()
    {
        var mockedBannedNamesService = new Mock<IProvideBannedNames>();
        mockedBannedNamesService.Setup(b => b.GetListOfBannedNames()).Returns(new List<string>() { "Jeff", "Bill" });

        var greeter = new GreetingMaker(mockedBannedNamesService.Object, _trollNotifierMock.Object);

        var greeting = greeter.Greet( "Jeff","Bill");

        _trollNotifierMock.Verify(b => b.Notify("User Used All Invalid Names: Jeff, Bill"), Times.Once);

       
    }
}
