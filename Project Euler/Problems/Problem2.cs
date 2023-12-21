namespace ProjectEuler.Problems
{
    internal class Problem2 : ProblemBase<Problem2>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var fibb1 = 1;
            var fibb2 = 2;
            var ans = 0;
            while (fibb1 < 4000000 & fibb2 < 4000000)
            {
                if (fibb1 % 2 == 0)
                    ans += fibb1;
                fibb1 += fibb2;
                if (fibb2 % 2 == 0)
                    ans += fibb2;
                fibb2 += fibb1;
            }
            return ans.ToString();
        }
    }
}

