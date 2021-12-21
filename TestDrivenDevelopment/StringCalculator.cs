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
            if (HasMultipleDelimiters(numbers))
                return SumForMultipleDelimiters(numbers);
            if (HasDelimiter(numbers))
                return SumForSingleDelimiter(numbers);
            return SumForDefaultDelimiters(numbers);
        }

        private static int SumForDefaultDelimiters(string numbers)
        {
            return TheIntegersFromTheString(NumberSplit(numbers, new string[] { "\n", "," }));
        }

        private static string[] NumberSplit(string numbers, string[] delimiters)
        {
            return numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private static int SumForSingleDelimiter(string numbers)
        {
            var delimiter = numbers.Skip(2).Take(1).Select(c => c.ToString()).ToArray();
            string stringWithoutDelimiter = numbers.Substring(numbers.IndexOf('\n') + 1);            
            return TheIntegersFromTheString(NumberSplit(stringWithoutDelimiter, delimiter));
        }

        private static int SumForMultipleDelimiters(string numbers)
        {
            var beginningString = numbers.Substring(2, (numbers.IndexOf("]\n") + 1) - 3);
            string firstNumberInString = numbers.Substring(numbers.IndexOf("]\n") + 1);
            var multipleDelimiters = beginningString.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            
            return TheIntegersFromTheString(NumberSplit(firstNumberInString, multipleDelimiters));
        }

        private static bool HasMultipleDelimiters(string delimiters)
        {
            return delimiters.Contains(']') && delimiters.Contains('[');
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

