using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    internal class Problem22 : ProblemBase<Problem22>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string allNames, currName = "", tempName;
            int y, tempSum;
            var names = new List<string>();
            using (StreamReader sr = new(Path))
            {
                allNames = sr.ReadToEnd();
            }
            foreach (char c in allNames)
            {
                if (c == '"')
                {
                    _ = allNames.Remove(c);
                    continue;
                }
                if (c == ',')
                {
                    names.Add(currName);
                    currName = "";
                    continue;
                }
                currName += c;
            }
            names.Add(currName);
            int n = names.Count;
            for (int w = 0; w < n; w++)
            {
                for (int x = 0; x < n - w - 1; x++)
                {
                    y = 0;
                    while (true)
                    {
                        if (y > names[x + 1].Length - 1 && y <= names[x].Length - 1)
                        {
                            tempName = names[x];
                            names[x] = names[x + 1];
                            names[x + 1] = tempName;
                            break;
                        }
                        if (y > names[x].Length - 1) break;
                        if (alphabet.IndexOf(names[x][y]) > alphabet.IndexOf(names[x + 1][y]))
                        {
                            tempName = names[x];
                            names[x] = names[x + 1];
                            names[x + 1] = tempName;
                        }
                        if (alphabet.IndexOf(names[x][y]) != alphabet.IndexOf(names[x + 1][y])) break;
                        y += 1;
                    }
                }
            }
            int ans = 0;
            for (int x = 0; x < n; x++)
            {
                tempSum = 0;
                for (int z = 0; z < names[x].Length; z++)
                {
                    tempSum += alphabet.IndexOf(names[x][z]) + 1;
                }
                ans += tempSum * (x + 1);
            }
            return ans.ToString();
        }
    }
}

