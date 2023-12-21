namespace ProjectEuler.Problems
{
    internal class Problem53 : ProblemBase<Problem53>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (uint i = 1; i <= 100; i++)
            {
                for (uint j = 1; j <= i; j++)
                {
                    if (UsefulTools.BinomialCooficient(i, j) > 1000000) ans++;
                }
            }
            return ans.ToString();
        }
    }
}

