﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringCalculatorTest")]
namespace TestDrivenDevelopment
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if(numbers == "") return 0;
                return int.Parse(numbers);
        }
    }
}
