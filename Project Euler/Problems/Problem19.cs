namespace ProjectEuler.Problems
{
    internal class Problem19 : ProblemBase<Problem19>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int dayOfWeek = 11, ans = 0;
            for (var i = 1901; i < 2001; i++)
            {
                if ((dayOfWeek + 4) % 7 == 0 | (dayOfWeek + 3) % 7 == 0 | (dayOfWeek + 1) % 7 == 0)
                {
                    ans += 2;
                }
                else ans += 1;

                if (i % 4 == 0)
                {
                    if (dayOfWeek % 7 == 0 | (dayOfWeek + 4) % 7 == 0)
                    {
                        ans += 1;
                    }
                }

                if (i % 4 != 0)
                {
                    if ((dayOfWeek + 1) % 7 == 0 | (dayOfWeek + 5) % 7 == 0)
                    {
                        ans += 1;
                    }
                }

                if (i % 4 == 3)
                {
                    dayOfWeek += 2;
                    continue;
                }

                dayOfWeek += 1;
            }

            return ans.ToString();
        }
    }
}

