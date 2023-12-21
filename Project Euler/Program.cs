using System;
using System.Diagnostics;
using ProjectEuler.Problems;
namespace ProjectEuler
{
    internal static class ProjectEuler
    {
        [Obsolete("Obsolete")]
        private static void Main()
        {
            var programActive = true;
            var chosenProblem = 0;
            const int numberOfProblems = 851;
            while (programActive)
            {
                var probNumBool = true;
                while (probNumBool)
                {
                    Console.WriteLine("\n(If you want to leave put 0):");
                    Console.WriteLine("\n(If you want to perform efficiency test put 1001):");
                    Console.WriteLine("\n(If you want to perform efficiency test and save data to file put 2002):");
                    Console.WriteLine("\n(If you want to write out avaliable problems put 3003):");
                    Console.WriteLine("\nPut the number of problem to see its answer or action you want to perform:");
                    var choice = Console.ReadLine();
                    if (int.TryParse(choice, out var intChoice))
                    {
                        if (intChoice <= numberOfProblems & intChoice >= 0 | intChoice == 1001 | intChoice == 2002 | intChoice == 3003)
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
                if (chosenProblem == 1001)
                {
                    Console.WriteLine("How many problems to check?");
                    var howManyToCheck = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many top problems to show?");
                    var howManyToShow = Convert.ToInt32(Console.ReadLine());
                    UsefulTools.EfficiencyTestTop(howManyToCheck, howManyToShow);
                    continue;
                }
                if (chosenProblem == 2002)
                {
                    Console.WriteLine("How many problems to check?");
                    var howManyToCheck2 = Convert.ToInt32(Console.ReadLine());
                    UsefulTools.EfficiencyTestToFile(howManyToCheck2);
                    Console.WriteLine("Efficiency test was performed succesfully!");
                    continue;
                }
                if(chosenProblem == 3003)
                {
                    UsefulTools.WriteOutSolved();
                }
                ProblemRunner.ChosenProblem(chosenProblem, true, true);
            }
        }
    }
}