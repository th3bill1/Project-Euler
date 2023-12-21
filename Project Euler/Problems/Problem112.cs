namespace ProjectEuler.Problems
{
    internal class Problem112 : ProblemBase<Problem112>
    {
        public new static string Answer => Solution();
        static string Solution()
        {
            var i = 100;
            var bouncy = 0;
            static bool IsBouncy(int x)
            {
                var arr = UsefulTools.DigitsOfNum(x);
                var ans1 = true;
                var ans2 = true;
                for (var i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > arr[i - 1]) ans1 = false;
                    if (arr[i] < arr[i - 1]) ans2 = false;
                }
                return !(ans1 || ans2);
            }
            while (true)
            {
                if (IsBouncy(i)) bouncy++;
                if (bouncy * 100 >= i * 99) return i.ToString();
                i++;
            }
        }
    }
}

