namespace ProjectEuler.Problems
{
    public class Problem1 : ProblemBase<Problem1>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            int answer = 0;
            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 | i % 5 == 0)
                    answer += i;
            }
            return answer.ToString();
        }
    }
}
