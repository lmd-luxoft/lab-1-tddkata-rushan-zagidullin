// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace TDDKata
{
    internal class StringCalc
    {
        internal int Sum(string numbersInput)
        {
            if (numbersInput == null)
            {
                return -1;
            }

            var numbers = numbersInput.Split(',');

            int sum = 0;
            foreach (var number in numbers)
            {
                int parsedNumber = 0;
                if (number != "" && (!int.TryParse(number, out parsedNumber) || parsedNumber < 0))
                {
                    return -1;
                }

                sum += parsedNumber;
            }
            return sum;
        }
    }
}