namespace ProjectEuler.Problems
{
    internal class Problem47 : ProblemBase<Problem47>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            static int PrmFacNum(int num)
            {
                return UsefulTools.Prime_factors(num).Length;
            }
            int i = 2;
            while (true)
            {
                if (PrmFacNum(i) == 4 && PrmFacNum(i + 1) == 4 && PrmFacNum(i + 2) == 4 && PrmFacNum(i + 3) == 4)
                {
                    return i.ToString();
                }
                i++;
            }
        }
    }
}

