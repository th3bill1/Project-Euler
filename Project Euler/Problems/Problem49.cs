namespace ProjectEuler.Problems
{
    internal class Problem49 : ProblemBase<Problem49>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            string ans = "";
            for (int i = 1000; i <= 9999; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    for (int j = 1; j < 8999; j++)
                    {
                        if (UsefulTools.IsPrime(i + j) && UsefulTools.IsPrime(i + 2 * j) && UsefulTools.IsPermutation(i, i + j) && UsefulTools.IsPermutation(i, i + 2 * j)) ans += i.ToString() + (i + j).ToString() + (i + 2 * j).ToString() + '\n';
                    }
                }
            }
            return ans;
        }
    }
}

