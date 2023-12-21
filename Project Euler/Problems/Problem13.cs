using System.Text.RegularExpressions;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem13 : ProblemBase<Problem13>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var oneHundredNumbers = UsefulTools.ProblemText(13);
            var strippedNumbers = Regex.Replace(oneHundredNumbers, "[^0-9]", "");
            strippedNumbers = strippedNumbers[4..];
            var currentDigit = 49;
            double digitsSum = 0, helper = 0;
            long ans = 0;
            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    digitsSum += Convert.ToInt32(strippedNumbers[j * 50 + currentDigit] - '0');
                }

                if (i > 39)
                {
                    ans += Convert.ToInt64((digitsSum - Math.Truncate(digitsSum / 10) * 10) *
                                                Math.Pow(10, helper));
                    helper += 1;
                }

                digitsSum = Math.Truncate(digitsSum / 10);
                currentDigit -= 1;
            }

            ans += Convert.ToInt64(digitsSum * Math.Pow(10, helper));
            ans = Convert.ToInt64(ans.ToString()[..10]);
            return ans.ToString();
        }
    }
}

