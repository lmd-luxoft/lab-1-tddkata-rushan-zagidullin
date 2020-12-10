// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (numbersInput == string.Empty)
            {
                return 0;
            }

            ExtractSeparators(numbersInput, out var separators, out var processingString);

            var numberStrings = processingString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Исходный цикл, отрефакторенный:
            int sum = 0;

            foreach (var numberString in numberStrings)
            {
                if (!CanParse(numberString))
                {
                    return -1;
                }

                var parsedNumber = int.Parse(numberString);

                if (IsNumberNegative(parsedNumber))
                {
                    return -1;
                }


                if (IsNumberTooLarge(parsedNumber))
                {
                    continue;
                }

                sum += parsedNumber;
            }

            // Аналогичный циклу результат через LINQ:

            //if (numberStrings.Any(x => !CanParse(x)))
            //{
            //    return -1;
            //}

            //var parsedNumbers = numberStrings
            //    .Select(x => int.Parse(x))
            //    .ToArray();

            //if (parsedNumbers.Any(IsNumberNegative))
            //{
            //    return -1;
            //}

            //var sum = parsedNumbers
            //    .Where(x => !IsNumberTooLarge(x))
            //    .Sum();

            return sum;
        }

        private bool CanParse(string value) => int.TryParse(value, out var _);
        private bool IsNumberNegative(int value) => value < 0;
        private bool IsNumberTooLarge(int value) => value > 1000;
        private void ExtractSeparators(string value, out string[] separators, out string newValue)
        {
            var match = Regex.Match(value, @"\/\/(.*)\n(.*)");

            if (match.Success)
            {
                separators = new[] { match.Groups[1].Value };
                newValue = match.Groups[2].Value;
                return;
            }

            separators = new []{ ",", "\n" };
            newValue = value;
        }
    }
}