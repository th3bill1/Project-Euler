using System.Collections.Generic;
using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem32 : ProblemBase<Problem32>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            List<int> list = new List<int>();
            for (int i = 2; i < 5001; i++)
            {
                for (int j = 2; j < 5001; j++)
                {
                    int k = i * j;
                    string num = i.ToString() + j.ToString() + (k).ToString();
                    if (num.Length != 9) continue;
                    if (UsefulTools.IsPandigital(Convert.ToInt32(num))) list.Add(k);
                }
            }
            foreach (int i in list.Distinct()) ans += i;
            return ans.ToString();
        }
    }
}

