using TestDrivenDevelopment;
using Xunit;


namespace TestProjectTDDInlämning
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Add_Returns_Zero_If_Empty_String()
        {
            var result = StringCalculator.Add("");

            Assert.Equal(0, result);
        }
    }
}