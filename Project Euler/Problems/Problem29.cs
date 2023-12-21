using System.Collections.Generic;
using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem29 : ProblemBase<Problem29>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            List<double> values = new();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    values.Add(Math.Pow(a, b));
                }
            }
            return values.Distinct().Count().ToString();
        }
    }
}

