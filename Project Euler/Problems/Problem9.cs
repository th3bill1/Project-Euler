using System;

namespace ProjectEuler.Problems
{
    internal class Problem9 : ProblemBase<Problem9>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;
            for (var i = 1; i < 500; i++)
            {
                for (var j = 2; j < 500; j++)
                {
                    var k = 1000 - i - j;
                    if (Convert.ToInt32(Math.Pow(i, 2)) + Convert.ToInt32(Math.Pow(j, 2)) !=
                        Convert.ToInt32(Math.Pow(k, 2))) continue;
                    ans = i * j * k;
                    goto Answer9;
                }
            }
        Answer9:
            return ans.ToString();
        }
    }
}

