namespace ProjectEuler.Problems
{
    internal class Problem17 : ProblemBase<Problem17>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (var i = 1; i <= 1000; i++)
            {
                var numberInWords = UsefulTools.NumberToWords(i).Replace(" ", "");
                ans += numberInWords.Length;
            }
            return ans.ToString();
        }
    }
}

