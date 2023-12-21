using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    internal class Problem51 : ProblemBase<Problem51>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            List<int> Familly(int[] digits, int starting_pos)
            {
                List<int> familly = new List<int>();
                int size = 0;
                int starting_digit = 0;
                int length = digits.Length;
                if (starting_pos < length)
                {
                    int[] new_digits = new int[length];
                    for (int i = 0; i < length; i++) new_digits[i] = digits[i];
                    new_digits[starting_pos++] = -1;

                    if (new_digits[0] == -1) starting_digit = 1;
                    for (int j = starting_digit; j < 10; j++)
                    {
                        int[] digits2 = new int[length];
                        for (int k = 0; k < length; k++)
                        {
                            if (new_digits[k] == -1) digits2[k] = j;
                            else digits2[k] = new_digits[k];
                        }
                        int value = (int)UsefulTools.DigitsToNum(digits2);
                        if (UsefulTools.IsPrime(value))
                        {
                            familly.Add(value);
                        }
                    }
                    if (Familly(digits, starting_pos).Count > familly.Count) familly = new List<int>(Familly(digits, starting_pos));
                    if (Familly(new_digits, starting_pos).Count > familly.Count) familly = new List<int>(Familly(new_digits, starting_pos));
                }
                return familly;
            }

            int num = 10;
            while (true)
            {
                if (UsefulTools.IsPrime(num) && (Familly(UsefulTools.DigitsOfNum(num), 0).Count == 8) && Familly(UsefulTools.DigitsOfNum(num), 0).Contains(num)) return num.ToString();
                num++;
            }
        }
    }
}

