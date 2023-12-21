using System;

namespace ProjectEuler.Problems
{
    internal class Problem36 : ProblemBase<Problem36>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if (i % 10 == 0 | i % 2 == 0) continue;
                if (UsefulTools.IsPalindrome(i) && UsefulTools.IsPalindromeString(Convert.ToString(i, 2))) ans += i;
            }
            return ans.ToString();
        }
    }
}

