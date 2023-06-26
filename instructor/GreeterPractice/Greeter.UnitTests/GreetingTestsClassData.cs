

using Moq;
using System.Collections;

namespace Greeter.UnitTests;
public class GreetingTestsRefactor
{
    private readonly GreetingMaker greeter;

    public GreetingTestsRefactor()
    {
        var dummyBannedNameService = new Mock<IProvideBannedNames>();
        dummyBannedNameService.Setup(d => d.GetListOfBannedNames()).Returns(new List<string>());

        greeter = new GreetingMaker(dummyBannedNameService.Object, new Mock<INotifyOfTrolls>().Object);
    }


    [Theory]
    [ClassData(typeof(ArbitraryNames1))]
    public void ArbitraryListOfNamesExampleWithClassData(string[] names, string expected)
    {

        string greeting = greeter.Greet(names);

        Assert.Equal(expected, greeting);
    }

}

public class ArbitraryNames1 : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new string[] { "Cole", "Cooper", "Rosenfield", "Preston", "Milford", "Jeffries" }, "Hello, Cole, Cooper, Rosenfield, Preston, Milford, and Jeffries!" };
        yield return new object[] { new string[] { "King", "Queen", "Princess" }, "Hello, King, Queen, and Princess!" };
        yield return new object[] { new string[] { "John", "Paul", "George", "Ringo" }, "Hello, John, Paul, George, and Ringo!" };

    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   
}

