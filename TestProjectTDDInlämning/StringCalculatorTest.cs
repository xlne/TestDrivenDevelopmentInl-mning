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

        [Fact]
        public void Add_Returns_Sum_For_One_Number()
        {
            var result = StringCalculator.Add("1");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_Returns_Sum_For_Two_Numbers()
        {
            var result = StringCalculator.Add("1,2");

            Assert.Equal(3, result);
        }
        
        [Fact]
        public void Add_Returns_Sum_For_Unknown_Amount_Numbers()
        {
            var result = StringCalculator.Add("1,2,8,3,5,9");

            Assert.Equal(28, result);
        } 
        
        [Fact]
        public void Add_Returns_Sum_Even_If_Numbers_Are_Separated_With_New_Line()
        {
            var result = StringCalculator.Add("1\n2\n8\n3\n5\n9");
            
            Assert.Equal(28, result);
        }
    }
}