using System;

namespace ProjectEuler.Problems
{
    internal class Problem46 : ProblemBase<Problem46>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            bool a = true;
            int answer = 3;
            while (a)
            {

                if (answer % 2 != 0 && !UsefulTools.IsPrime(answer))
                {
                    for (int j = 1; j <= Math.Sqrt(answer / 2); j++)
                    {
                        if (UsefulTools.IsPrime(answer - Convert.ToInt32(Math.Pow(j, 2)) * 2)) goto NextNum;
                    }
                    a = false;
                }
            NextNum:
                answer++;
            }
            return (answer - 1).ToString();
        }
    }
}

