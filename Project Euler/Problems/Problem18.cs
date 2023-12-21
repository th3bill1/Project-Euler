using System.IO;
using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class Problem18 : ProblemBase<Problem18>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int linesNumber = 0, triangularCounter1 = 0;
            using (var sr = new StreamReader(Path))
            {
                while (sr.ReadLine() is { })
                {
                    linesNumber += 1;
                }
            }

            var triangleTable = new string[linesNumber, linesNumber];
            using (var sr = new StreamReader(Path))
            {
                while (sr.ReadLine() is { } line)
                {
                    var triangularCounter2 = 0;
                    foreach (var s in line.Where(s => string.IsNullOrWhiteSpace(s.ToString()) != true))
                    {
                        triangleTable[triangularCounter1, triangularCounter2 / 2] += s;
                        triangularCounter2 += 1;
                    }

                    triangularCounter1 += 1;
                }
            }

            for (var h = linesNumber - 2; h >= 0; h--)
            {
                for (var i = 0; i < linesNumber - 2; i++)
                {
                    if (Convert.ToInt32(triangleTable[h + 1, i]) >
                        Convert.ToInt32(triangleTable[h + 1, i + 1]))
                    {
                        triangleTable[h, i] = Convert.ToString(Convert.ToInt32(triangleTable[h, i]) +
                                                               Convert.ToInt32(triangleTable[h + 1, i]));
                    }
                    else
                        triangleTable[h, i] = Convert.ToString(Convert.ToInt32(triangleTable[h, i]) +
                                                               Convert.ToInt32(triangleTable[h + 1, i + 1]));
                }
            }

            return triangleTable[0, 0];
        }
    }
}

