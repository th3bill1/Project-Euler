using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public static class ProblemsSolved
    {
        private static string _path;
        public static int ChosenProblemNumber;
        private static bool _isShowingAnswer;
        const string sol = "Solution for problem:";

        public static void ChosenProblem(int chosenProblemNumber, bool showAnswer, bool _isShowingTime)
        {
            var chosenProblemName = "Problem" + Convert.ToString(chosenProblemNumber);
            var type = typeof(ProblemsSolved);
            var info = type.GetMethod(chosenProblemName);
            if (info != null)
            {
                ChosenProblemNumber = chosenProblemNumber;
                _isShowingAnswer = showAnswer;
                _path = $@"{Environment.CurrentDirectory}..\..\..\..\problem{ChosenProblemNumber}.txt";
                if (_isShowingAnswer)
                {
                    Console.WriteLine(UsefulTools.ProblemText(chosenProblemNumber));
                    Console.WriteLine(sol);
                }
                var stopwatch = new Stopwatch();

                if (_isShowingTime) stopwatch.Start();

                info.Invoke(null, null);

                if (_isShowingTime)
                {
                    stopwatch.Stop();
                    var ts = stopwatch.Elapsed;
                    Console.WriteLine(UsefulTools.TimeConversion(ts));
                }
            }
            else if (_isShowingAnswer) Console.WriteLine("There is no solution for this problem avaliable!");
        }

        public static void Problem1()
        {
            var answer = 0;
            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 | i % 5 == 0)
                    answer += i;
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer);
        }

        public static void Problem2()
        {
            int fibb1 = 1, fibb2 = 2, answer = 0;
            while (fibb1 < 4000000 & fibb2 < 4000000)
            {
                if (fibb1 % 2 == 0)
                    answer += fibb1;
                fibb1 += fibb2;
                if (fibb2 % 2 == 0)
                    answer += fibb2;
                fibb2 += fibb1;
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer);
        }

        public static void Problem3()
        {
            const double num = 600851475143;
            double answer = 0;
            for (var i = Convert.ToInt32(Math.Sqrt(num)); i > 1; i--)
            {
                if (num % i != 0 || !UsefulTools.IsPrime(i)) continue;
                answer = i;
                break;
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer);
        }

        public static void Problem4()
        {
            var answer4 = 0;
            for (var i = 999; i > 0; i--)
            {
                for (var j = 999; j > 0; j--)
                {
                    if (i * j > answer4 && UsefulTools.IsPalindrome(i * j))
                        answer4 = i * j;
                }
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer4);
        }

        public static void Problem5()
        {
            var answer5 = 1;
            for (var i = 1; i <= 20; i++)
            {
                answer5 = UsefulTools.Lcm(answer5, i);
            }

            if (_isShowingAnswer) 
                Console.WriteLine(answer5);
        }

        public static void Problem6()
        {
            int squareSum = 0, sumSquare = 0;
            for (var i = 1; i <= 100; i++)
            {
                sumSquare += Convert.ToInt32(Math.Pow(i, 2));
            }

            for (var i = 1; i <= 100; i++)
            {
                squareSum += i;
            }

            squareSum = Convert.ToInt32(Math.Pow(squareSum, 2));
            var answer6 = squareSum - sumSquare;

            if (_isShowingAnswer)
                Console.WriteLine(answer6);
        }

        public static void Problem7()
        {
            int answer7 = 1, counter = 1;
            while (counter < 10001)
            {
                answer7 += 2;
                if (UsefulTools.IsPrime(answer7))
                {
                    counter += 1;
                }
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer7);
        }

        [Obsolete("Obsolete")]
        public static void Problem8()
        {
            long answer8 = 0;
            var thousandDigitNumber = Regex.Replace(UsefulTools.ProblemText(8), "[^0-9]", "")[13..];
            thousandDigitNumber = thousandDigitNumber.Remove(thousandDigitNumber.Length - 4);
            var digits = new char[thousandDigitNumber.Length];
            var digitIndex = 0;
            foreach (var s in thousandDigitNumber)
            {
                digits[digitIndex] = s;
                digitIndex += 1;
            }

            for (var i = 1; i < 888; i++)
            {
                long multiply = Convert.ToInt16(digits[i] - '0');
                for (var j = 1; j < 13; j++)
                {
                    multiply *= Convert.ToInt16(digits[i + j] - '0');
                }

                if (multiply > answer8)
                    answer8 = multiply;
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer8);
        }

        public static void Problem9()
        {
            var answer9 = 0;
            for (var i = 1; i < 500; i++)
            {
                for (var j = 2; j < 500; j++)
                {
                    var k = 1000 - i - j;
                    if (Convert.ToInt32(Math.Pow(i, 2)) + Convert.ToInt32(Math.Pow(j, 2)) !=
                        Convert.ToInt32(Math.Pow(k, 2))) continue;
                    answer9 = i * j * k;
                    goto Answer9;
                }
            }

        Answer9:
            if (_isShowingAnswer) 
                Console.WriteLine(answer9);
        }
        public static void Problem10()
        {
            long answer10 = 0;
            for (var i = 1; i < 2000000; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    answer10 += i;
                }
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer10);
        }
        [Obsolete("Obsolete")]
        public static void Problem11()
        {
            long answer11 = 0;
            var twentyByTwenty = Regex.Replace(UsefulTools.ProblemText(11), "[^0-9]", "")[6..];
            twentyByTwenty = twentyByTwenty.Remove(twentyByTwenty.Length - 19);
            var numbers = new string[400];
            for (int i = 0; i < twentyByTwenty.Length; i += 2)
                numbers[i / 2] = (twentyByTwenty.Substring(i, 2));
            var numbersGrid = new int[20, 20];
            var gridNumber = 0;
            var columnNumber = 0;
            foreach (var s in numbers)
            {
                if (columnNumber == 20)
                {
                    gridNumber += 1;
                    columnNumber = 0;
                }

                numbersGrid[gridNumber, columnNumber] = Convert.ToInt16(s);
                columnNumber += 1;
            }

            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    long tempNum1;
                    if (i < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j] * numbersGrid[i + 2, j] *
                                   numbersGrid[i + 3, j];
                        if (tempNum1 > answer11)
                            answer11 = tempNum1;
                    }

                    if (j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i, j + 1] * numbersGrid[i, j + 2] *
                                   numbersGrid[i, j + 3];
                        if (tempNum1 > answer11)
                            answer11 = tempNum1;
                    }

                    if (i < 17 && j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j + 1] *
                                   numbersGrid[i + 2, j + 2] *
                                   numbersGrid[i + 3, j + 3];
                        if (tempNum1 > answer11)
                            answer11 = tempNum1;
                    }

                    if (i < 17 && j > 2)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j - 1] *
                                   numbersGrid[i + 2, j - 2] *
                                   numbersGrid[i + 3, j - 3];
                        if (tempNum1 > answer11)
                            answer11 = tempNum1;
                    }
                }
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer11);
        }
        public static void Problem12()
        {
            int answer12 = 1, noTh = 2;
            while (true)
            {
                if (UsefulTools.NumberOfDivisors(answer12) >= 500)
                    break;
                answer12 += noTh;
                noTh += 1;
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer12);
        }
        [Obsolete("Obsolete")]
        public static void Problem13()
        {
            var oneHundredNumbers = UsefulTools.ProblemText(13);
            var strippedNumbers = Regex.Replace(oneHundredNumbers, "[^0-9]", "");
            strippedNumbers = strippedNumbers[4..];
            var currentDigit = 49;
            double digitsSum = 0, helper = 0;
            long answer13 = 0;
            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    digitsSum += Convert.ToInt32(strippedNumbers[j * 50 + currentDigit] - '0');
                }

                if (i > 39)
                {
                    answer13 += Convert.ToInt64((digitsSum - Math.Truncate(digitsSum / 10) * 10) *
                                                Math.Pow(10, helper));
                    helper += 1;
                }

                digitsSum = Math.Truncate(digitsSum / 10);
                currentDigit -= 1;
            }

            answer13 += Convert.ToInt64(digitsSum * Math.Pow(10, helper));
            answer13 = Convert.ToInt64(answer13.ToString()[..10]);
            if (_isShowingAnswer)
                Console.WriteLine(answer13);
        }
        public static void Problem14()
        {
            long answer14 = 0, tempmax = 0;
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
                answer14 = i;
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer14);
        }
        public static void Problem15()
        {
            if (_isShowingAnswer) 
                Console.WriteLine(UsefulTools.BinomialCooficient(40, 20));
        }
        public static void Problem16()
        {
            var answer16 = 0;
            double tempTwoPowers = 0;
            var twoPowersDigits = new int[303];
            twoPowersDigits[0] = 2;
            for (var i = 0; i < 999; i++)
            {
                var numberOfDigitsOfTwoPowersDigit = twoPowersDigits.Length;
                for (var j = 0; j < numberOfDigitsOfTwoPowersDigit; j++)
                {
                    tempTwoPowers += twoPowersDigits[j] * 2;
                    twoPowersDigits[j] = Convert.ToInt32(tempTwoPowers % 10);
                    tempTwoPowers = Math.Truncate(tempTwoPowers / 10);
                }
            }

            for (var i = 0; i < 303; i++)
            {
                answer16 += twoPowersDigits[i];
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer16);
        }
        public static void Problem17()
        {
            var answer17 = 0;
            for (var i = 1; i <= 1000; i++)
            {
                var numberInWords = UsefulTools.NumberToWords(i).Replace(" ", "");
                answer17 += numberInWords.Length;
            }

            if (_isShowingAnswer) 
                Console.WriteLine(answer17);
        }
        public static void Problem18()
        {
            int linesNumber = 0, triangularCounter1 = 0;
            using (var sr = new StreamReader(_path))
            {
                while (sr.ReadLine() is { })
                {
                    linesNumber += 1;
                }
            }

            var triangleTable = new string[linesNumber, linesNumber];
            using (var sr = new StreamReader(_path))
            {
                while (sr.ReadLine() is { } line)
                {
                    var triangularCounter2 = 0;
                    foreach (var s in line.Where(s => string.IsNullOrWhiteSpace(s.ToString()) != true))
                    {
                        triangleTable[triangularCounter1, triangularCounter2 / 2] += s;
                        triangularCounter2 += 1;
                    }

                    triangularCounter1 += 1;
                }
            }

            for (var h = linesNumber - 2; h >= 0; h--)
            {
                for (var i = 0; i < linesNumber - 2; i++)
                {
                    if (Convert.ToInt32(triangleTable[h + 1, i]) >
                        Convert.ToInt32(triangleTable[h + 1, i + 1]))
                    {
                        triangleTable[h, i] = Convert.ToString(Convert.ToInt32(triangleTable[h, i]) +
                                                               Convert.ToInt32(triangleTable[h + 1, i]));
                    }
                    else
                        triangleTable[h, i] = Convert.ToString(Convert.ToInt32(triangleTable[h, i]) +
                                                               Convert.ToInt32(triangleTable[h + 1, i + 1]));
                }
            }

            if (_isShowingAnswer) 
                Console.WriteLine(triangleTable[0, 0]);

            
        }
        public static void Problem19()
        {
            int dayOfWeek = 11, answer19 = 0;
            for (var i = 1901; i < 2001; i++)
            {
                if ((dayOfWeek + 4) % 7 == 0 | (dayOfWeek + 3) % 7 == 0 | (dayOfWeek + 1) % 7 == 0)
                {
                    answer19 += 2;
                }
                else answer19 += 1;

                if (i % 4 == 0)
                {
                    if (dayOfWeek % 7 == 0 | (dayOfWeek + 4) % 7 == 0)
                    {
                        answer19 += 1;
                    }
                }

                if (i % 4 != 0)
                {
                    if ((dayOfWeek + 1) % 7 == 0 | (dayOfWeek + 5) % 7 == 0)
                    {
                        answer19 += 1;
                    }
                }

                if (i % 4 == 3)
                {
                    dayOfWeek += 2;
                    continue;
                }

                dayOfWeek += 1;
            }

            if (_isShowingAnswer) 
                Console.WriteLine(answer19);
        }
        public static void Problem20()
        {
            var answer20 = 0;
            double tempFactorial = 0;
            var factorial = new int[159];
            factorial[0] = 1;
            for (var i = 0; i < 100; i++)
            {
                var numberOfDigitsOfFactorial = factorial.Length;
                for (var j = 0; j < numberOfDigitsOfFactorial; j++)
                {
                    tempFactorial += factorial[j] * (i + 1);
                    factorial[j] = Convert.ToInt32(tempFactorial % 10);
                    tempFactorial = Math.Truncate(tempFactorial / 10);
                }
            }

            for (var i = 0; i < 159; i++)
            {
                answer20 += factorial[i];
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer20);
        }
        public static void Problem21()
        {
            var answer21 = 0;
            for (var i = 1; i < 10000; i++)
            {
                if (UsefulTools.SumOfProperDivisors(i) != i &&
                    UsefulTools.SumOfProperDivisors(UsefulTools.SumOfProperDivisors(i)) == i)
                    answer21 += i;
            }

            if (_isShowingAnswer)
                Console.WriteLine(answer21);
        }
        public static void Problem22()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string allNames, currName = "", tempName;
            int y, tempSum;
            var names = new List<string>();
            using (StreamReader sr = new(_path))
            {
                allNames = sr.ReadToEnd();
            }
            foreach (char c in allNames)
            {
                if (c=='"')
                {
                    _ = allNames.Remove(c);
                    continue;
                }
                if (c==',')
                {
                    names.Add(currName);
                    currName = "";
                    continue;
                }
                currName += c;
            }
            names.Add(currName);
            int n = names.Count;
            for (int w = 0; w < n; w++)
            {
                for (int x = 0; x < n-w-1; x++)
                {
                    y = 0;
                    while (true)
                    {
                        if (y > names[x+1].Length - 1 && y <= names[x].Length - 1)
                        {
                            tempName = names[x];
                            names[x] = names[x + 1];
                            names[x + 1] = tempName;
                            break;
                        }
                        if (y > names[x].Length-1) break;
                        if (alphabet.IndexOf(names[x][y]) > alphabet.IndexOf(names[x + 1][y]))
                        {
                            tempName = names[x];
                            names[x] = names[x + 1];
                            names[x + 1] = tempName;
                        }
                        if (alphabet.IndexOf(names[x][y]) != alphabet.IndexOf(names[x + 1][y])) break;
                        y += 1;
                    }
                }
            }
            int answer22 = 0;
            for (int x = 0; x< n;x++)
            {
                tempSum = 0;
                for(int z = 0; z < names[x].Length;z++)
                {
                    tempSum+=alphabet.IndexOf(names[x][z])+1;
                }
                answer22 += tempSum*(x+1);
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer22);


        }
        public static void Problem23()
        {
            long answer23 = 0;

            bool IsAbundant(int x)
            {
                return UsefulTools.SumOfProperDivisors(x) > x;
            }

            bool CanBeWrittenAsSumOfAbundant(int i)
            {
                for (var j = 2; j < i / 2 + 1; j++)
                {
                    if (IsAbundant(j) && IsAbundant(i - j)) return true;
                }

                return false;
            }

            for (var i = 1; i < 28124; i++)
            {
                if (!CanBeWrittenAsSumOfAbundant(i)) answer23 += i;
            }

            if (_isShowingAnswer) 
                Console.WriteLine(answer23);
        }
        public static void Problem24()
        {
            var milion = 1000000;
            string digitsS = "0123456789", answer24 = "";
            for (var i = 0; i < 10; i++)
            {
                var max = 0;
                for (var j = 1; j < 10; j++)
                {
                    if (UsefulTools.Factorial(10 - (i + 1)) * j < milion)
                    {
                        max = j;
                    }
                }
                answer24 += digitsS[max];
                digitsS = digitsS.Remove(max, 1);
                milion -= UsefulTools.Factorial(10 - (i + 1)) * max;
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer24);
        }
        public static void Problem25()
        {
            double fibbLength = 0;
            var indexFibb = 2;
            BigInteger currentFibb1 = 1, currentFibb2 = 1;
            while (fibbLength < 1000)
            {
                currentFibb2 += currentFibb1;
                currentFibb1 += currentFibb2;
                fibbLength = BigInteger.Log10(currentFibb1) + 1;
                indexFibb += 2;
            }

            BigInteger answer25 = BigInteger.Log10(currentFibb2) + 1 >= 1000 ? indexFibb - 1 : indexFibb;
            if (_isShowingAnswer) 
                Console.WriteLine(answer25);
        }
        public static void Problem27()
        {
            int answer27 = 0, y = 0;
            for (var a = -999; a < 1000; a++)
            {
                for (var b = -999; b < 1000; b++)
                {
                    int x = 0;
                    while (true)
                    {
                        if (!UsefulTools.IsPrime(Convert.ToInt32(Math.Pow(x, 2) + a * x + b))) break;
                        x++;
                    }
                    if (x > y)
                    {
                        y = x;
                        answer27 = a * b;
                    }
                }
            }
            if (_isShowingAnswer) 
                Console.WriteLine(answer27);
        }
        public static void Problem28()
        {
            int max = 1001*1001, answer = 0, addition = 2, tempnum = 1;
            while (tempnum<=max)
            {
                for (int i = 1; i<5; i++)
                {
                    answer += tempnum;
                    tempnum += addition;
                    if (tempnum > max) break;
                }
                addition += 2;
            }
            if (_isShowingAnswer)
                Console.WriteLine(answer);
        }
        public static void Problem36()
        {
            var answer = 0;
            for (int i = 1; i<1000000; i++)
            {
                if (i % 10 == 0 | i % 2 == 0) continue;
                if (UsefulTools.IsPalindrome(i) && UsefulTools.IsPalindromeString(Convert.ToString(i, 2))) answer += i;
            }
            if (_isShowingAnswer)
                Console.WriteLine(answer);
        }
        public static void Problem46()
        {
            bool a = true;
            int answer = 3;
            while(a)
            {
                
                if (answer % 2 != 0 && !UsefulTools.IsPrime(answer))
                {
                    for (int j = 1; j <= Math.Sqrt(answer / 2); j++)
                    {
                        if (UsefulTools.IsPrime(answer - Convert.ToInt32(Math.Pow(j, 2)) * 2)) goto NextNum;
                    }
                    a = false;
                }
                NextNum:
                answer++;
            }
            if (_isShowingAnswer)
               Console.WriteLine(answer-1);
        }
        public static void Problem67()
        {
            Problem18();
        }
        public static void Problem2137()
        {
            Console.WriteLine("Karzel ded");
            var p = new Process
            {
                StartInfo = new ProcessStartInfo($@"{Environment.CurrentDirectory}..\..\..\..\gnome-bonk.gif")
                { UseShellExecute = true }
            };
            p.Start();
        }
       
    }
}