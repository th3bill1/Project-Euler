namespace ProjectEuler.Problems
{
    internal class Problem14 : ProblemBase<Problem14>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            long ans = 0, tempmax = 0;
            for (var i = 1; i < 1000000; i++)
            {
                var chainLength = 0;
                long currNum = i;
                while (currNum > 1)
                {
                    chainLength += 1;
                    switch (currNum % 2)
                    {
                        case 0:
                            currNum /= 2;
                            break;
                        case 1:
                            currNum = currNum * 3 + 1;
                            break;
                    }
                }

                if (chainLength <= tempmax) continue;
                tempmax = chainLength;
                ans = i;
            }
            return ans.ToString();
        }
    }
}

