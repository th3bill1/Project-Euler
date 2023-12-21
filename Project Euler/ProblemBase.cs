using System;
using System.Linq;

namespace ProjectEuler
{
    public abstract class ProblemBase<T> where T : ProblemBase<T>
    {
        public static int Number
        {
            get
            {
                var name = typeof(T).ToString();
                var number = name[^name.Reverse().TakeWhile(char.IsDigit).Count()..];
                _ = int.TryParse(number, out int num);
                return num;
            }
        }
        public static string Description
        {
            get => UsefulTools.ProblemText(Number);
        }
        public static string Answer
        {
            get => "There is no answer for this Problem!";
        }
        public static string Path
        {
            get => $@"{Environment.CurrentDirectory}..\..\..\..\Inputs\problem{Number}.txt";
        }
    }
}
