namespace ProjectEuler.Problems
{
    internal class Problem10 : ProblemBase<Problem10>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;
            for (var i = 1; i < 2000000; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    ans += i;
                }
            }
            return ans.ToString();
        }
    }
}

