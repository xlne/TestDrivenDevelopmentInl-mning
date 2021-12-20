using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringCalculatorTest")]
namespace TestDrivenDevelopment
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {            
            if (string.IsNullOrEmpty(numbers))
                return 0;
            if (HasDelimiter(numbers))
            {
                string delimiter = new(numbers.Skip(2).Take(1).ToArray());
                string stringWithoutDelimiter = numbers.Substring(numbers.IndexOf('\n') + 1);
                var numbersArray = stringWithoutDelimiter.Split(delimiter);
                

                return TheIntegersFromTheString(numbersArray);
            }
            else
            {
                var numbersArray = numbers.Split(new string[] { "\n", "," }, StringSplitOptions.None);

                return TheIntegersFromTheString(numbersArray);
            }
        }     

        private static int TheIntegersFromTheString(string[] numbersArray)
        {
            var ints = numbersArray.Select(theString => int.Parse(theString));
            ThrowExceptionIfNegativeNumber(ints);
            if (IfNumberIsBiggerThan1000(ints))
            {
                ints = ints.Where(n => n <= 1000);
            }
            return ints.Sum();
        }

        private static bool IfNumberIsBiggerThan1000(IEnumerable<int> ints)
        {
            return ints.Any(num => num > 1000);
        }

        private static void ThrowExceptionIfNegativeNumber(IEnumerable<int> numberArray)
        {
            var negativeNumbers = numberArray.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                string negativeString = String.Join(',', negativeNumbers
                .Select(n => n.ToString()));
                throw new ArgumentException($"Negatives not allowed: {negativeString}");
            }
        }

        private static bool HasDelimiter(string numbers)
        {
            return numbers.StartsWith("//");
        }
    }
}

