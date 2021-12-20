using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringCalculatorTest")]
namespace TestDrivenDevelopment
{
    public class StringCalculator
    {
        private static string? delimiter;

        public static int Add(string numbers)
        {            
            if(string.IsNullOrEmpty(numbers)) 
                return 0;
            else if (HasDelimiter(numbers))
            {
                if (numbers.StartsWith("//"))
                {
                    delimiter = new string(numbers.Skip(2).Take(1).ToArray());
                    string stringWithoutDelimiter = numbers.Substring(numbers.IndexOf('\n') + 1);
                    var arrayString = stringWithoutDelimiter.Split(delimiter);
                    var numberArray = arrayString.Select(theString => int.Parse(theString));
                    return numberArray.Sum();
                }

                var stringArray = numbers.Split(new string[] { "\n", "," }, StringSplitOptions.None);
                var numbersArray = stringArray.Select(str => int.Parse(str));
                return numbersArray.Sum();
            }                    
            return int.Parse(numbers);
        }

        private static bool HasDelimiter(string numbers)
        {
            return numbers.StartsWith("//") || numbers.Contains('\n') || numbers.Contains(',');
        }
    }
}
