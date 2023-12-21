namespace ProjectEuler.Problems
{
    internal class Problem33 : ProblemBase<Problem33>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int num = 0;
            int[,] fractions = new int[4, 2];
            for (double a = 1; a < 10; a++)
            {
                for (double b = 1; b < 10; b++)
                {
                    for (double c = 1; c < 10; c++)
                    {
                        for (double d = 1; d < 10; d++)
                        {
                            double e = (10 * a + b) / (10 * c + d);
                            if (e < 1 && ((e == a / c && b == d) || (e == a / d && b == c) || (e == b / c && a == d) || (e == b / d && a == c)))
                            {

                                fractions[num, 0] = (int)(10 * a + b);
                                fractions[num, 1] = (int)(10 * c + d);
                                num++;
                            }
                        }
                    }
                }
            }
            int numerator = fractions[0, 0] * fractions[1, 0] * fractions[2, 0] * fractions[3, 0];
            int denominator = fractions[0, 1] * fractions[1, 1] * fractions[2, 1] * fractions[3, 1];
            denominator /= UsefulTools.Gcf(numerator, denominator);
            return denominator.ToString();
        }
    }
}

