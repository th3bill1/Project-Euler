namespace ProjectEuler.Problems
{
    internal class Problem34 : ProblemBase<Problem34>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            var sum = 0;
            for (int i = 10; i < 600000; i++)
            {
                sum = 0;
                int j = i;
                while (j > 0)
                {
                    sum += UsefulTools.Factorial(j % 10);
                    j /= 10;
                }
                if (sum == i) ans += i;
            }
            return ans.ToString();
        }
    }
}

