namespace ProjectEuler.Problems
{
    internal class Problem24 : ProblemBase<Problem24>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var milion = 1000000;
            string digitsS = "0123456789", ans = "";
            for (var i = 0; i < 10; i++)
            {
                var max = 0;
                for (var j = 1; j < 10; j++)
                {
                    if (UsefulTools.Factorial(10 - (i + 1)) * j < milion)
                    {
                        max = j;
                    }
                }
                ans += digitsS[max];
                digitsS = digitsS.Remove(max, 1);
                milion -= UsefulTools.Factorial(10 - (i + 1)) * max;
            }
            return ans;
        }
    }
}

