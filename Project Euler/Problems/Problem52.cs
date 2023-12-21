using System.Linq;
using System;

namespace ProjectEuler.Problems
{
    internal class Problem52 : ProblemBase<Problem52>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            bool IsSameDigitMultiple(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (!IsSameDigit(nums[i], nums[j])) return false;
                    }
                }
                return true;
            }
            bool IsSameDigit(int num1, int num2)
            {
                int[] digits1 = UsefulTools.DigitsOfNum(num1);
                int[] digits2 = UsefulTools.DigitsOfNum(num2);
                if (Math.Floor(Math.Log10(num1)) != Math.Floor(Math.Log10(num2))) return false;
                foreach (int digit in digits1) if (!digits2.Contains(digit)) return false;
                return true;
            }
            int i = 1;
            while (true)
            {
                int[] digits = { i, 2 * i, 3 * i, 4 * i, 5 * i, 6 * i };
                if (IsSameDigitMultiple(digits)) return i.ToString();
                i++;
            }
        }
    }
}

