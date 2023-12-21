using System;
namespace ProjectEuler.Problems
{
    internal class Problem3 : ProblemBase<Problem3>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            const double num = 600851475143;
            double ans = 0;
            for (var i = Convert.ToInt32(Math.Sqrt(num)); i > 1; i--)
            {
                if (num % i != 0 || !UsefulTools.IsPrime(i)) continue;
                ans = i;
                break;
            }
            return ans.ToString();
        }
    }
}

