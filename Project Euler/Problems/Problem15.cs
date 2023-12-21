namespace ProjectEuler.Problems
{
    internal class Problem15 : ProblemBase<Problem15>
    {
        public new static string Answer => Solution();
        static string Solution() => UsefulTools.BinomialCooficient(40, 20).ToString();
    }
}

