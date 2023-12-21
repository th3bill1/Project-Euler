using System.Collections.Generic;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem40 : ProblemBase<Problem40>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var i = 1;
            List<int> list = new() { 0 };
            while (list.Count < 1000001)
            {
                foreach (char c in i.ToString()) list.Add(Convert.ToInt32(c.ToString()));
                i++;
            }
            return (list[1] * list[10] * list[100] * list[1000] * list[10000] * list[100000] * list[1000000]).ToString();
        }
    }
}

