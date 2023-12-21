namespace ProjectEuler.Problems
{
    internal class Problem21 : ProblemBase<Problem21>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (var i = 1; i < 10000; i++)
            {
                if (UsefulTools.SumOfProperDivisors(i) != i &&
                    UsefulTools.SumOfProperDivisors(UsefulTools.SumOfProperDivisors(i)) == i)
                    ans += i;
            }
            return ans.ToString();
        }
    }
}

