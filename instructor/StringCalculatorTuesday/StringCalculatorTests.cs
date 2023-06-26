
namespace StringCalculator;

public class StringCalculatorTests
{
    StringCalculator _calculator = new StringCalculator();
    [Fact]
    public void EmptyStringReturnsZero()
    {

        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("118", 118)]
    public void SingleDigit(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("10,8", 18)]
    [InlineData("108,32", 140)]
    public void TwoDigits(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("12,100", 112)]
   
    public void ArbitraryNumbers(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2\n3", 6)]
    [InlineData("5\n5", 10)]
    [InlineData("1\n2,5", 8)]
    public void NewLinesAsDelimeters(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//*\n1*99", 100)]
   
    public void CustomDelimeters(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("//;\n1;2,3", 6)]
    [InlineData("//~\n1,2\n3~10", 16)]
    

    public void CustomDelimetersMixedWithStandard(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }


}
