using System;

namespace ProjectEuler.Problems
{
    internal class Problem39 : ProblemBase<Problem39>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            static bool IsRightTriangle(int a, int b, int c)
            {
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) return true;
                return false;
            }
            int ans = 0, value = 0;
            for (int i = 1; i <= 1000; i++)
            {
                int temp_value = 0;
                for (int a = 1; a < i / 2; a++)
                {
                    for (int b = 1; b < i / 2; b++)
                    {
                        int c = i - (a + b);
                        if (a >= b && a >= c && IsRightTriangle(b, c, a)) temp_value++;
                        if (b >= a && b >= c && IsRightTriangle(a, c, b)) temp_value++;
                        if (c >= b && c >= a && IsRightTriangle(b, a, c)) temp_value++;
                    }
                }
                if (temp_value > value)
                {
                    value = temp_value;
                    ans = i;
                }
            }
            return ans.ToString();
        }
    }
}

