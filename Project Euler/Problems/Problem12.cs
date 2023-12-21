namespace ProjectEuler.Problems
{
    internal class Problem12 : ProblemBase<Problem12>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int ans = 1, noTh = 2;
            while (true)
            {
                if (UsefulTools.NumberOfDivisors(ans) >= 500)
                    break;
                ans += noTh;
                noTh += 1;
            }
            return ans.ToString();
        }
    }
}

