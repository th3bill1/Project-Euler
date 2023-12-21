using System;

namespace ProjectEuler.Problems
{
    internal class Problem27 : ProblemBase<Problem27>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int ans = 0, y = 0;
            for (var a = -999; a < 1000; a++)
            {
                for (var b = -999; b < 1000; b++)
                {
                    int x = 0;
                    while (true)
                    {
                        if (!UsefulTools.IsPrime(Convert.ToInt32(Math.Pow(x, 2) + a * x + b))) break;
                        x++;
                    }
                    if (x > y)
                    {
                        y = x;
                        ans = a * b;
                    }
                }
            }
            return ans.ToString();
        }
    }
}

