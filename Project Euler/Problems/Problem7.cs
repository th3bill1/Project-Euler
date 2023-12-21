namespace ProjectEuler.Problems
{
    internal class Problem7 : ProblemBase<Problem7>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 1;
            var counter = 1;
            while (counter < 10001)
            {
                ans += 2;
                if (UsefulTools.IsPrime(ans))
                {
                    counter += 1;
                }
            }
            return ans.ToString();
        }
    }
}

