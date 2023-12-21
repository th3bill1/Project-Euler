namespace ProjectEuler.Problems
{
    internal class Problem23 : ProblemBase<Problem23>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;

            bool IsAbundant(int x)
            {
                return UsefulTools.SumOfProperDivisors(x) > x;
            }

            bool CanBeWrittenAsSumOfAbundant(int i)
            {
                for (var j = 2; j < i / 2 + 1; j++)
                {
                    if (IsAbundant(j) && IsAbundant(i - j)) return true;
                }

                return false;
            }

            for (var i = 1; i < 28124; i++)
            {
                if (!CanBeWrittenAsSumOfAbundant(i)) ans += i;
            }
            return ans.ToString();
        }
    }
}

