using System;

namespace ProjectEuler.Problems
{
    internal class Problem6 : ProblemBase<Problem6>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int squareSum = 0, sumSquare = 0;
            for (var i = 1; i <= 100; i++)
            {
                sumSquare += Convert.ToInt32(Math.Pow(i, 2));
            }

            for (var i = 1; i <= 100; i++)
            {
                squareSum += i;
            }

            squareSum = Convert.ToInt32(Math.Pow(squareSum, 2));
            var ans = squareSum - sumSquare;

            return ans.ToString();
        }
    }
}

