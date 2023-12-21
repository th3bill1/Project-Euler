using System;

namespace ProjectEuler.Problems
{
    internal class Problem58 : ProblemBase<Problem58>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int num_of_primes_diagonal = 3, start = 3;
            while ((double)num_of_primes_diagonal / (start * 2 - 1) >= 0.1)
            {
                int first_num = (int)Math.Pow(start, 2) + 1;
                if (UsefulTools.IsPrime(first_num + start)) num_of_primes_diagonal++;
                if (UsefulTools.IsPrime(first_num + (start * 2) + 1)) num_of_primes_diagonal++;
                if (UsefulTools.IsPrime(first_num + (start * 3) + 2)) num_of_primes_diagonal++;
                start += 2;
            }
            return start.ToString();
        }
    }
}

