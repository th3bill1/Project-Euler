using System.Text.RegularExpressions;
using System;

namespace ProjectEuler.Problems
{
    internal partial class Problem8 : ProblemBase<Problem8>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;
            var thousandDigitNumber = MyRegex().Replace(UsefulTools.ProblemText(8), "")[13..];
            thousandDigitNumber = thousandDigitNumber.Remove(thousandDigitNumber.Length - 4);
            var digits = new char[thousandDigitNumber.Length];
            var digitIndex = 0;
            foreach (var s in thousandDigitNumber)
            {
                digits[digitIndex] = s;
                digitIndex += 1;
            }

            for (var i = 1; i < 888; i++)
            {
                long multiply = Convert.ToInt16(digits[i] - '0');
                for (var j = 1; j < 13; j++)
                {
                    multiply *= Convert.ToInt16(digits[i + j] - '0');
                }

                if (multiply > ans)
                    ans = multiply;
            }

            return ans.ToString();
        }

        [GeneratedRegex("[^0-9]")]
        private static partial Regex MyRegex();
    }
}

