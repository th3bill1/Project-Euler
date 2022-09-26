using ProjectEuler;
using System;
using System.Diagnostics;

namespace Project_Euler
{
    internal static class ProjectEuler
    {
        [Obsolete("Obsolete")]
        private static void Main()
        {
            var programActive = true;
            var chosenProblem = 0;
            const string sol = "Solution for problem:";
            while (programActive)
            {
                var probNumBool = true;
                while (probNumBool)
                {
                    Console.WriteLine("\nPut the number of problem to see its answer (If you want to leave put 0):");
                    var choice = Console.ReadLine();
                    if (int.TryParse(choice, out var intChoice))
                    {
                        if (intChoice < 807 & intChoice >= 0 | intChoice == 2137)
                        {
                            chosenProblem = intChoice;
                            probNumBool = false;
                        }
                        else Console.WriteLine("Problem with this number does not exist!");
                    }
                    else Console.WriteLine("This is not a number! Try again:");
                }
                if (chosenProblem == 0)
                {
                    Console.WriteLine("Thanks for using the program! It will shut down now.");
                    programActive = false;
                }

                Console.WriteLine(UsefulTools.ProblemText(chosenProblem));
                Console.WriteLine(sol);

                var stopwatch = new Stopwatch();

                stopwatch.Start();
                ProblemsSolved.ChoosingProblem(chosenProblem);
                stopwatch.Stop();

                var ts = stopwatch.Elapsed;
                var minimum = new TimeSpan(0, 0, 0, 0, 1);
                var timeSpent = "";
                if (ts.Days > 0) timeSpent += $"{ts.Days} days ";
                if (ts.Hours > 0) timeSpent += $"{ts.Hours} hours ";
                if (ts.Minutes > 0) timeSpent += $"{ts.Minutes} minutes ";
                if (ts.Seconds > 0) timeSpent += $"{ts.Seconds} seconds and ";
                if (ts.Milliseconds >= 0) timeSpent += $"{ts.Milliseconds} miliseconds";
                if (ts > minimum)
                {
                    Console.WriteLine($"Solution took {timeSpent}."); continue;
                }
                Console.WriteLine("Solution took less than 1 milisecond!");
            }
        }
    }
}