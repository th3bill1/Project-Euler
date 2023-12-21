using System;

namespace ProjectEuler.Problems
{
    internal class Problem37 : ProblemBase<Problem37>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (int i = 10, j = 0; j < 11; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    int k = i, l = 1;
                    while (k > 0)
                    {
                        k /= 10;
                        int m = i - (int)(k * Math.Pow(10, l));
                        if (!(UsefulTools.IsPrime(k) && UsefulTools.IsPrime(m))) break;
                        l++;
                    }
                    if (l == Math.Floor(Math.Log10(i) + 1))
                    {
                        ans += i;
                        j++;
                    }
                }
            }
            return ans.ToString();
        }
    }
}

