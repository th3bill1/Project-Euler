using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class Problem25 : ProblemBase<Problem25>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            double fibbLength = 0;
            var indexFibb = 2;
            BigInteger currentFibb1 = 1, currentFibb2 = 1;
            while (fibbLength < 1000)
            {
                currentFibb2 += currentFibb1;
                currentFibb1 += currentFibb2;
                fibbLength = BigInteger.Log10(currentFibb1) + 1;
                indexFibb += 2;
            }

            BigInteger ans = BigInteger.Log10(currentFibb2) + 1 >= 1000 ? indexFibb - 1 : indexFibb;
            return ans.ToString();
        }
    }
}

