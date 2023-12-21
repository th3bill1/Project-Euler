using System.Numerics;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem43 : ProblemBase<Problem43>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            BigInteger sum = 0;
            foreach (var pan in UsefulTools.PandigitalNumsDescending(10, 0))
            {
                if (pan.ToString()[1..4] is { } s1 && Convert.ToInt32(s1) % 2 != 0) continue;
                if (pan.ToString()[2..5] is { } s2 && Convert.ToInt32(s2) % 3 != 0) continue;
                if (pan.ToString()[3..6] is { } s3 && Convert.ToInt32(s3) % 5 != 0) continue;
                if (pan.ToString()[4..7] is { } s4 && Convert.ToInt32(s4) % 7 != 0) continue;
                if (pan.ToString()[5..8] is { } s5 && Convert.ToInt32(s5) % 11 != 0) continue;
                if (pan.ToString()[6..9] is { } s6 && Convert.ToInt32(s6) % 13 != 0) continue;
                if (pan.ToString()[7..10] is { } s7 && Convert.ToInt32(s7) % 17 != 0) continue;
                sum += pan;
            }
            return sum.ToString();
        }
    }
}

