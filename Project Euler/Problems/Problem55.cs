using System.Numerics;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem55 : ProblemBase<Problem55>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            BigInteger ReverseNum(BigInteger x)
            {
                BigInteger y = 0, xsize = (int)Math.Floor(Math.Log10((double)x) + 1);
                while (x > 0)
                {
                    y += (BigInteger)Math.Pow(10, (double)xsize - 1) * (x % 10);
                    xsize--;
                    x /= 10;
                }
                return y;
            }
            for (int i = 1; i < 10000; i++)
            {
                int n = 0;
                BigInteger num = i;
                do
                {
                    num += ReverseNum(num);
                    n++;
                } while (n < 50 && !UsefulTools.IsPalindrome(num));
                if (n == 50) ans++;
            }
            return ans.ToString();
        }
    }
}

