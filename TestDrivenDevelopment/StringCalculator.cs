using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringCalculatorTest")]
namespace TestDrivenDevelopment
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            string newLine = "\n";

            if(string.IsNullOrEmpty(numbers)) return 0;
            
            if (numbers.Contains(','))
            {
                var stringArray = numbers.Split(',');
                return stringArray.Select(number => int.Parse(number)).Sum();
            }
            else if (numbers.Contains(newLine))
            {
            var numberPart = numbers.Split(newLine.ToCharArray());
                return numberPart.Select(number => int.Parse(number)).Sum();

            }
            return int.Parse(numbers);
        }
    }
}
