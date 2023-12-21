namespace ProjectEuler.Problems
{
    internal class Problem28 : ProblemBase<Problem28>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int max = 1001 * 1001, ans = 0, addition = 2, tempnum = 1;
            while (tempnum <= max)
            {
                for (int i = 1; i < 5; i++)
                {
                    ans += tempnum;
                    tempnum += addition;
                    if (tempnum > max) break;
                }
                addition += 2;
            }
            return ans.ToString();
        }
    }
}

