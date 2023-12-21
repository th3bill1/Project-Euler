using System.Diagnostics;
using System;

namespace ProjectEuler
{
    internal class ProblemRunner
    {
        public static int ChosenProblemNumber;
        private static bool _isShowingAnswer;
        const string sol = "Solution for problem:";

        public static bool ChosenProblem(int chosenProblemNumber, bool showAnswer, bool _isShowingTime)
        {
            var chosenProblemName = "Problem" + Convert.ToString(chosenProblemNumber);
            var type = Type.GetType(string.Format("{0}.{1}", "ProjectEuler.Problems", chosenProblemName));
            var info = type.GetProperty("Answer");
            if (info != null)
            {
                ChosenProblemNumber = chosenProblemNumber;
                _isShowingAnswer = showAnswer;
                if (_isShowingAnswer)
                {
                    Console.WriteLine(UsefulTools.ProblemText(chosenProblemNumber));
                    Console.WriteLine(sol);
                }
                var stopwatch = new Stopwatch();

                if (_isShowingTime) stopwatch.Start();

                var answer = info.GetValue(type);
                if (_isShowingAnswer)
                    Console.WriteLine(answer);

                if (_isShowingTime)
                {
                    stopwatch.Stop();
                    var ts = stopwatch.Elapsed;
                    Console.WriteLine(UsefulTools.TimeConversion(ts));
                }
                return true;
            }
            else if (_isShowingAnswer)
            {
                Console.WriteLine("There is no solution for this problem avaliable!");
            }
            return false;
        }
        public static bool DoesProblemExist(int problemNumber)
        {
            var chosenProblemName = "Problem" + Convert.ToString(problemNumber);
            var type = Type.GetType(string.Format("{0}.{1}", "ProjectEuler.Problems", chosenProblemName));
            return type == null;
        }
    }
}

