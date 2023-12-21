using System;

namespace ProjectEuler.Problems
{
    internal class Problem35 : ProblemBase<Problem35>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (int i = 2; i < 1000000; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    bool is_prime = true;
                    int num_of_digits = (int)Math.Floor(Math.Log10(i) + 1);
                    int j = i;
                    do
                    {
                        int k = j % 10;
                        j /= 10;
                        j += k * (int)Math.Pow(10, num_of_digits - 1);
                        if (!UsefulTools.IsPrime(j)) is_prime = false;
                    } while (j != i);
                    if (is_prime) ans++;
                }
            }
            return ans.ToString();
        }
    }
}

