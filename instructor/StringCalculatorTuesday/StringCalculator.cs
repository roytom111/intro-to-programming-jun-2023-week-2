
using System.Globalization;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers == "") { return 0; }
        var delimeters = new List<char> { ',', '\n' };
        if(numbers.StartsWith("//")) {

            var customDelimeter = numbers.Substring(2, 1);
            delimeters.Add(char.Parse(customDelimeter));
            numbers = numbers.Substring(4);
        }
       
        return numbers.Split(delimeters.ToArray()).Select(int.Parse).Sum();
        
    }
}
