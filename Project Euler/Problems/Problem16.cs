using System;

namespace ProjectEuler.Problems
{
    internal class Problem16 : ProblemBase<Problem16>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;
            double tempTwoPowers = 0;
            var twoPowersDigits = new int[303];
            twoPowersDigits[0] = 2;
            for (var i = 0; i < 999; i++)
            {
                var numberOfDigitsOfTwoPowersDigit = twoPowersDigits.Length;
                for (var j = 0; j < numberOfDigitsOfTwoPowersDigit; j++)
                {
                    tempTwoPowers += twoPowersDigits[j] * 2;
                    twoPowersDigits[j] = Convert.ToInt32(tempTwoPowers % 10);
                    tempTwoPowers = Math.Truncate(tempTwoPowers / 10);
                }
            }

            for (var i = 0; i < 303; i++)
            {
                ans += twoPowersDigits[i];
            }
            return ans.ToString();
        }
    }
}

