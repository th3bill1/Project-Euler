namespace ProjectEuler.Problems
{
    internal class Problem4 : ProblemBase<Problem4>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (var i = 999; i > 0; i--)
            {
                for (var j = 999; j > 0; j--)
                {
                    if (i * j > ans && UsefulTools.IsPalindrome(i * j))
                        ans = i * j;
                }
            }
            return ans.ToString();
        }
    }
}

