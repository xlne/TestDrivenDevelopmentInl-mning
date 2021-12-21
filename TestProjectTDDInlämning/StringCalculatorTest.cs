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

        [Fact]
        public void Add_Will_Return_Argument_Exception_Message_With_All_Negative_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var mess = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-2,2"));
            Assert.Equal("Negatives not allowed: -2", mess.Message);
        }
        
        [Fact]
        public void Add_Will_Return_All_Negative_Numbers_If_Passed_In_Several()
        {
            var stringCalculator = new StringCalculator();
            var mess = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-2,2,-50,-8"));
            Assert.Equal("Negatives not allowed: -2,-50,-8", mess.Message);
        }
        
        [Fact]
        public void Add_Will_Ignore_Numbers_Over_1000()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1001, 5, 9, 1000");
            Assert.Equal(1014, result);
        }

        [Fact]
        public void Add_Will_Include_Delimiters_Of_Any_Length()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[***]\n1***2***3");
            Assert.Equal(6, result);
        }
        
        [Fact]
        public void Add_Will_Allow_Multiple_Different_Delimiters()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[*][%]\n1*2%3");
            Assert.Equal(6, result);
        }
        
        [Fact]
        public void Add_Will_Allow_Multiple_Different_Delimiters_Longer_Than_One_Char()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[**][%%%]\n1**2%%%3");
            Assert.Equal(6, result);
        }
    }
}