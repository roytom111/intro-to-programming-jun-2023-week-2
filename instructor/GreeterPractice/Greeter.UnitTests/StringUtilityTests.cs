
namespace Greeter.UnitTests;
public class StringUtilityTests
{
    [Theory]
    [InlineData("Jayden", "J****n")]
    [InlineData("Hi", "H*")]
    [InlineData("X", "X")]
    public void CanDoIt(string name, string expected)
    {
       var result = StringUtilties.Elide(name);

        
        var result2 = name.Elide();

        Assert.Equal(expected, result);
        Assert.Equal(expected, result2);

    }
}
