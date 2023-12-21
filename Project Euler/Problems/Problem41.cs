namespace ProjectEuler.Problems
{
    internal class Problem41 : ProblemBase<Problem41>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            PrimeChecker pm = new();

            var i = 9;
            while (i > 0)
            {
                foreach (var j in UsefulTools.PandigitalNumsDescending(i, 1)) if (pm.IsPrime(j)) return j.ToString();
                i--;
            }
            return "";
        }
    }
}

