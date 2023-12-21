namespace ProjectEuler.Problems
{
    internal class Problem31 : ProblemBase<Problem31>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var ans = 0;
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        for (int d = 0; d < 11; d++)
                        {
                            for (int e = 0; e < 21; e++)
                            {
                                for (int f = 0; f < 41; f++)
                                {
                                    for (int g = 0; g < 101; g++)
                                    {
                                        for (int h = 0; h < 201; h++)
                                        {
                                            int x = a * 200 + b * 100 + c * 50 + d * 20 + e * 10 + f * 5 + g * 2 + h;
                                            if (x > 200) break;
                                            if (x == 200) ans++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ans.ToString();
        }
    }
}

