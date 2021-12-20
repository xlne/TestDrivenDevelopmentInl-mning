using System;
using TestDrivenDevelopment;
using Xunit;


namespace TestProjectTDDInlämning
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Add_Returns_Zero_If_Empty_String()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_Returns_Sum_For_One_Number()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1");

            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_Returns_Sum_For_Two_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1,2");

            Assert.Equal(3, result);
        }
        
        [Fact]
        public void Add_Returns_Sum_For_Unknown_Amount_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1,2,8,3,5,9");

            Assert.Equal(28, result);
        } 
        
        [Fact]
        public void Add_Returns_Sum_Even_If_Numbers_Are_Separated_With_New_Line()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1\n2\n8\n3\n5\n9");
            
            Assert.Equal(28, result);
        }

        [Fact]
        public void Add_Supports_Different_Delimiters()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//D\n1D2D3");
            
            Assert.Equal(6, result);
        }
                      
        [Fact]
        public void Add_Will_Not_Accept_Negative_Numbers()
        {
            var stringCalculator = new StringCalculator();
            Assert.Throws<ArgumentException>(() => stringCalculator.Add("-2,2"));
        }

        [Fact]
        public void Add_Will_Return_Argument_Exception_Message_If_Contains_Negative_Numbers()
        {
            var stringCalculator = new StringCalculator();
            Assert.Throws<ArgumentException>(() => stringCalculator.Add("-2,2"));
        }

    }
}