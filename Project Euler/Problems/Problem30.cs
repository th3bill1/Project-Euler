using System;

namespace ProjectEuler.Problems
{
    internal class Problem30 : ProblemBase<Problem30>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int ans = 0;
            int[] a = new int[10];
            for (int i = 0; i < 10; i++) a[i] = (int)Math.Pow(i, 5);
            for (int i = 2; i < 999999; i++)
            {
                int k = i, l = 0;
                while (k > 0)
                {
                    l += a[k % 10];
                    k /= 10;
                }
                if (l == i) ans += i;
            }
            return ans.ToString();
        }
    }
}

