using System.Text.RegularExpressions;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem11 : ProblemBase<Problem11>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0;
            var twentyByTwenty = Regex.Replace(UsefulTools.ProblemText(11), "[^0-9]", "")[6..];
            twentyByTwenty = twentyByTwenty.Remove(twentyByTwenty.Length - 19);
            var numbers = new string[400];
            for (int i = 0; i < twentyByTwenty.Length; i += 2)
                numbers[i / 2] = (twentyByTwenty.Substring(i, 2));
            var numbersGrid = new int[20, 20];
            var gridNumber = 0;
            var columnNumber = 0;
            foreach (var s in numbers)
            {
                if (columnNumber == 20)
                {
                    gridNumber += 1;
                    columnNumber = 0;
                }

                numbersGrid[gridNumber, columnNumber] = Convert.ToInt16(s);
                columnNumber += 1;
            }

            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    long tempNum1;
                    if (i < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j] * numbersGrid[i + 2, j] *
                                   numbersGrid[i + 3, j];
                        if (tempNum1 > ans)
                            ans = tempNum1;
                    }

                    if (j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i, j + 1] * numbersGrid[i, j + 2] *
                                   numbersGrid[i, j + 3];
                        if (tempNum1 > ans)
                            ans = tempNum1;
                    }

                    if (i < 17 && j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j + 1] *
                                   numbersGrid[i + 2, j + 2] *
                                   numbersGrid[i + 3, j + 3];
                        if (tempNum1 > ans)
                            ans = tempNum1;
                    }

                    if (i < 17 && j > 2)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j - 1] *
                                   numbersGrid[i + 2, j - 2] *
                                   numbersGrid[i + 3, j - 3];
                        if (tempNum1 > ans)
                            ans = tempNum1;
                    }
                }
            }
            return ans.ToString();
        }
    }
}

