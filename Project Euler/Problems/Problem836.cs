namespace ProjectEuler.Problems
{
    internal class Problem836 : ProblemBase<Problem836>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            string text = UsefulTools.HTMLText(836);
            string answer = "";
            bool isbold = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '<' && text[i + 1] == 'b' && text[i + 2] == '>')
                {
                    answer += text[i + 3];
                    isbold = true;
                }
                if (isbold && text[i] == ' ') answer += text[i + 1];
                if (text[i] == '<' && text[i + 1] == '/' && text[i + 2] == 'b' && text[i + 3] == '>') isbold = false;
            }
            return answer;
        }
    }
}

