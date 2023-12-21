namespace ProjectEuler.Problems
{
    internal class Problem5 : ProblemBase<Problem5>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 1;
            for (var i = 1; i <= 20; i++)
            {
                ans = UsefulTools.Lcm(ans, i);
            }
            return ans.ToString();
        }
    }
}

