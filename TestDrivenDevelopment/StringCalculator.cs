using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringCalculatorTest")]
namespace TestDrivenDevelopment
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;
            else if (numbers.Contains(','))
            {
                var stringArray = numbers.Split(',');
                var numbersArray = stringArray.Select(number => int.Parse(number));
                var sum = numbersArray.Sum();
                return sum;
            }
                return int.Parse(numbers);
        }
    }
}
