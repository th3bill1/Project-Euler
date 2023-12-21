using System;

namespace ProjectEuler.Problems
{
    internal class Problem20 : ProblemBase<Problem20>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            double tempFactorial = 0;
            var factorial = new int[159];
            factorial[0] = 1;
            for (var i = 0; i < 100; i++)
            {
                var numberOfDigitsOfFactorial = factorial.Length;
                for (var j = 0; j < numberOfDigitsOfFactorial; j++)
                {
                    tempFactorial += factorial[j] * (i + 1);
                    factorial[j] = Convert.ToInt32(tempFactorial % 10);
                    tempFactorial = Math.Truncate(tempFactorial / 10);
                }
            }

            for (var i = 0; i < 159; i++)
            {
                ans += factorial[i];
            }

            return ans.ToString();
        }
    }
}

