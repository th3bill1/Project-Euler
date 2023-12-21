using System;

namespace ProjectEuler.Problems
{
    internal class Problem38 : ProblemBase<Problem38>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            static int ToPandigital_maxsize9(int number, int max_multiple)
            {
                string temp = "";
                for (int i = 0; i < max_multiple; i++)
                {
                    temp += (number * (i + 1)).ToString();
                }
                if (temp.Length > 9 || !UsefulTools.IsPandigital(Convert.ToInt32(temp))) return 0;
                return Convert.ToInt32(temp);
            }
            for (int i = 2; i < 20; i++)
            {
                for (int j = 1; j < 50000; j++)
                {
                    int k = ToPandigital_maxsize9(j, i);
                    if (k > ans) ans = k;
                }
            }
            return ans.ToString();
        }
    }
}

