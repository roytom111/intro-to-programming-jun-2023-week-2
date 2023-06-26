

namespace CSharpStuff;
public class MethodsDetails
{
    [Fact]
    public void CanAddTwoNumbers()
    {
        var math = new MathThing();

        var answer = math.Add(2, 2);
        Assert.Equal(4, answer);
    }

    [Fact]
    public void CanAddThreeNumbers()
    {
        var math = new MathThing();

        var answer = math.Add(1, 2, 3);

       
        Assert.Equal(6, answer);
    }

    [Fact]
    public void CanAddABunchOfIntegers()
    {
        var math = new MathThing();

        var answer1 = math.Add(1, 2, 3, 4, 5, 6,  7, 8, 9);
        Assert.Equal(45, answer1);

        var answer2 = math.Add(10, 20, 30, 40);

        var extraNumbers = new int[] { 3, 4, 5, 6, 7, 8, 9 };
        var answer3= math.Add(1, 2, extraNumbers);
        Assert.Equal(45, answer3);
    }
}


public class MathThing
{
    public int Add(int a, int b,  params int[] rest)
    {
        return a + b + rest.Sum();
    }
    //public int Add(int a, int b, int c)
    //{
    //    return Add(a, b) + c;
    //}
}