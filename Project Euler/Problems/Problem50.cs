using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    internal class Problem50 : ProblemBase<Problem50>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            PrimeChecker pm = new();
            int ans = 0, max = 0;
            List<int> primes = new();
            for (int i = 2; i < 1000000; i++) if (pm.IsPrime(i)) primes.Add(i);
            for (int i = 0; i < primes.Count; i++)
            {
                int sum = 0, j = i;
                while (sum < 1000000 && j < primes.Count)
                {
                    sum += primes[j];
                    if (pm.IsPrime(sum) && sum > max && j - i > max)
                    {
                        max = j - i;
                        ans = sum;
                    }
                    j++;
                }
            }
            return ans.ToString();
        }
    }
}

