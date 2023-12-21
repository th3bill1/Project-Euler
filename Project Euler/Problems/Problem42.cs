using System.IO;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem42 : ProblemBase<Problem42>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            static bool IsTriangular(int i)
            {
                for (int j = 1; j < 2 * i; j++)
                {
                    if (j * (j + 1) == 2 * i) return true;
                }
                return false;
            }
            string text;
            using (StreamReader sr = new(Path))
            {
                text = sr.ReadToEnd();
            }
            int value = 0, ans = 0;
            foreach (char c in text)
            {
                if (c == '"' && value > 0)
                {
                    if (IsTriangular(value)) ans++;
                    value = 0;
                }
                else if (char.IsLetter(c)) value += Convert.ToInt16(c) - 64;
            }
            return ans.ToString();
        }
    }
}

