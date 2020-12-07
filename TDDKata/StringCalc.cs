// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

            string[] separators = {",", "\n"};

            var match = Regex.Match(numbersInput, "\\/\\/(.*)\\\n(.*)");
            if (match.Success)
            {
                separators = new [] {match.Groups[1].Value};
                numbersInput = match.Groups[2].Value;
            }


            var numbers = numbersInput.Split(separators, StringSplitOptions.None);

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