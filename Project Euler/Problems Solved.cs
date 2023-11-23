using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public static class ProblemsSolved
    {
        private static string _path;
        public static int ChosenProblemNumber;
        private static bool _isShowingAnswer;
        const string sol = "Solution for problem:";

        public static bool ChosenProblem(int chosenProblemNumber, bool showAnswer, bool _isShowingTime)
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

                var answer = info.Invoke(null, null);
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
            var type = typeof(ProblemsSolved);
            return !(type.GetMethod(chosenProblemName) == null);
        }

        public static int Problem1()
        {
            int answer = 0;
            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 | i % 5 == 0)
                    answer += i;
            }
            return answer;
        }

        public static int Problem2()
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
            return answer;
        }

        public static double Problem3()
        {
            const double num = 600851475143;
            double answer = 0;
            for (var i = Convert.ToInt32(Math.Sqrt(num)); i > 1; i--)
            {
                if (num % i != 0 || !UsefulTools.IsPrime(i)) continue;
                answer = i;
                break;
            }
            return answer;
        }

        public static long Problem4()
        {
            var answer = 0;
            for (var i = 999; i > 0; i--)
            {
                for (var j = 999; j > 0; j--)
                {
                    if (i * j > answer && UsefulTools.IsPalindrome(i * j))
                        answer = i * j;
                }
            }
            return answer;
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

        public static int Problem6()
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
            int answer = squareSum - sumSquare;

            return answer;
        }

        public static int Problem7()
        {
            int answer = 1, counter = 1;
            while (counter < 10001)
            {
                answer += 2;
                if (UsefulTools.IsPrime(answer))
                {
                    counter += 1;
                }
            }
            return answer;
        }

        [Obsolete("Obsolete")]
        public static long Problem8()
        {
            long answer = 0;
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

                if (multiply > answer)
                    answer = multiply;
            }

            return answer;
        }

        public static long Problem9()
        {
            long answer = 0;
            for (var i = 1; i < 500; i++)
            {
                for (var j = 2; j < 500; j++)
                {
                    var k = 1000 - i - j;
                    if (Convert.ToInt32(Math.Pow(i, 2)) + Convert.ToInt32(Math.Pow(j, 2)) !=
                        Convert.ToInt32(Math.Pow(k, 2))) continue;
                    answer = i * j * k;
                    goto Answer9;
                }
            }
        Answer9:
            return answer;
        }
        public static long Problem10()
        {
            long answer = 0;
            for (var i = 1; i < 2000000; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    answer += i;
                }
            }

            return answer;
        }
        [Obsolete("Obsolete")]
        public static long Problem11()
        {
            long answer = 0;
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
                        if (tempNum1 > answer)
                            answer = tempNum1;
                    }

                    if (j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i, j + 1] * numbersGrid[i, j + 2] *
                                   numbersGrid[i, j + 3];
                        if (tempNum1 > answer)
                            answer = tempNum1;
                    }

                    if (i < 17 && j < 17)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j + 1] *
                                   numbersGrid[i + 2, j + 2] *
                                   numbersGrid[i + 3, j + 3];
                        if (tempNum1 > answer)
                            answer = tempNum1;
                    }

                    if (i < 17 && j > 2)
                    {
                        tempNum1 = numbersGrid[i, j] * numbersGrid[i + 1, j - 1] *
                                   numbersGrid[i + 2, j - 2] *
                                   numbersGrid[i + 3, j - 3];
                        if (tempNum1 > answer)
                            answer = tempNum1;
                    }
                }
            }

            return answer;
        }
        public static int Problem12()
        {
            int answer = 1, noTh = 2;
            while (true)
            {
                if (UsefulTools.NumberOfDivisors(answer) >= 500)
                    break;
                answer += noTh;
                noTh += 1;
            }

            return answer;
        }
        [Obsolete("Obsolete")]
        public static long Problem13()
        {
            var oneHundredNumbers = UsefulTools.ProblemText(13);
            var strippedNumbers = Regex.Replace(oneHundredNumbers, "[^0-9]", "");
            strippedNumbers = strippedNumbers[4..];
            var currentDigit = 49;
            double digitsSum = 0, helper = 0;
            long answer = 0;
            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    digitsSum += Convert.ToInt32(strippedNumbers[j * 50 + currentDigit] - '0');
                }

                if (i > 39)
                {
                    answer += Convert.ToInt64((digitsSum - Math.Truncate(digitsSum / 10) * 10) *
                                                Math.Pow(10, helper));
                    helper += 1;
                }

                digitsSum = Math.Truncate(digitsSum / 10);
                currentDigit -= 1;
            }

            answer += Convert.ToInt64(digitsSum * Math.Pow(10, helper));
            answer = Convert.ToInt64(answer.ToString()[..10]);

            return answer;
        }
        public static long Problem14()
        {
            long answer = 0, tempmax = 0;
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
                answer = i;
            }

            return answer;
        }
        public static long Problem15()
        {
            return UsefulTools.BinomialCooficient(40, 20);
        }
        public static long Problem16()
        {
            long answer = 0;
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
                answer += twoPowersDigits[i];
            }

            return answer;
        }
        public static int Problem17()
        {
            int answer = 0;
            for (var i = 1; i <= 1000; i++)
            {
                var numberInWords = UsefulTools.NumberToWords(i).Replace(" ", "");
                answer += numberInWords.Length;
            }

            return answer;
        }
        public static string Problem18()
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

            return triangleTable[0, 0];
        }
        public static int Problem19()
        {
            int dayOfWeek = 11, answer = 0;
            for (var i = 1901; i < 2001; i++)
            {
                if ((dayOfWeek + 4) % 7 == 0 | (dayOfWeek + 3) % 7 == 0 | (dayOfWeek + 1) % 7 == 0)
                {
                    answer += 2;
                }
                else answer += 1;

                if (i % 4 == 0)
                {
                    if (dayOfWeek % 7 == 0 | (dayOfWeek + 4) % 7 == 0)
                    {
                        answer += 1;
                    }
                }

                if (i % 4 != 0)
                {
                    if ((dayOfWeek + 1) % 7 == 0 | (dayOfWeek + 5) % 7 == 0)
                    {
                        answer += 1;
                    }
                }

                if (i % 4 == 3)
                {
                    dayOfWeek += 2;
                    continue;
                }

                dayOfWeek += 1;
            }

            return answer;
        }
        public static int Problem20()
        {
            var answer = 0;
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
                answer += factorial[i];
            }

            return answer;
        }
        public static int Problem21()
        {
            int answer = 0;
            for (var i = 1; i < 10000; i++)
            {
                if (UsefulTools.SumOfProperDivisors(i) != i &&
                    UsefulTools.SumOfProperDivisors(UsefulTools.SumOfProperDivisors(i)) == i)
                    answer += i;
            }

            return answer;
        }
        public static int Problem22()
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
                if (c == '"')
                {
                    _ = allNames.Remove(c);
                    continue;
                }
                if (c == ',')
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
                for (int x = 0; x < n - w - 1; x++)
                {
                    y = 0;
                    while (true)
                    {
                        if (y > names[x + 1].Length - 1 && y <= names[x].Length - 1)
                        {
                            tempName = names[x];
                            names[x] = names[x + 1];
                            names[x + 1] = tempName;
                            break;
                        }
                        if (y > names[x].Length - 1) break;
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
            int answer = 0;
            for (int x = 0; x < n; x++)
            {
                tempSum = 0;
                for (int z = 0; z < names[x].Length; z++)
                {
                    tempSum += alphabet.IndexOf(names[x][z]) + 1;
                }
                answer += tempSum * (x + 1);
            }
            return answer;
        }
        public static long Problem23()
        {
            long answer = 0;

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
                if (!CanBeWrittenAsSumOfAbundant(i)) answer += i;
            }

            return answer;
        }
        public static string Problem24()
        {
            var milion = 1000000;
            string digitsS = "0123456789", answer = "";
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
                answer += digitsS[max];
                digitsS = digitsS.Remove(max, 1);
                milion -= UsefulTools.Factorial(10 - (i + 1)) * max;
            }
            return answer;
        }
        public static BigInteger Problem25()
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

            BigInteger answer = BigInteger.Log10(currentFibb2) + 1 >= 1000 ? indexFibb - 1 : indexFibb;
            return answer;
        }
        public static int Problem27()
        {
            int answer = 0, y = 0;
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
                        answer = a * b;
                    }
                }
            }
            return answer;
        }
        public static int Problem28()
        {
            int max = 1001 * 1001, answer = 0, addition = 2, tempnum = 1;
            while (tempnum <= max)
            {
                for (int i = 1; i < 5; i++)
                {
                    answer += tempnum;
                    tempnum += addition;
                    if (tempnum > max) break;
                }
                addition += 2;
            }
            return answer;
        }
        public static int Problem29()
        {
            List<double> values = new();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    values.Add(Math.Pow(a, b));
                }
            }
            return values.Distinct().Count();
        }
        public static int Problem30()
        {
            int answer = 0;
            int[] a = new int[10];
            for (int i = 0; i < 10; i++) a[i] = (int)Math.Pow(i, 5);
            for (int i = 2; i < 999999; i++)
            {
                int k = i, l = 0;
                while (k > 0)
                {
                    l += a[k % 10];
                    k /= 10;
                }
                if (l == i) answer += i;
            }
            return answer;
        }
        public static int Problem31()
        {
            int answer = 0;

            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        for (int d = 0; d < 11; d++)
                        {
                            for (int e = 0; e < 21; e++)
                            {
                                for (int f = 0; f < 41; f++)
                                {
                                    for (int g = 0; g < 101; g++)
                                    {
                                        for (int h = 0; h < 201; h++)
                                        {
                                            int x = a * 200 + b * 100 + c * 50 + d * 20 + e * 10 + f * 5 + g * 2 + h;
                                            if (x > 200) break;
                                            if (x == 200) answer++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return answer;
        }
        public static int Problem32()
        {
            int answer = 0;
            List<int> list = new List<int>();
            for (int i = 2; i < 5001; i++)
            {
                for (int j = 2; j < 5001; j++)
                {
                    int k = i * j;
                    string num = i.ToString() + j.ToString() + (k).ToString();
                    if (num.Length != 9) continue;
                    if (UsefulTools.IsPandigital(Convert.ToInt32(num))) list.Add(k);
                }
            }
            foreach (int i in list.Distinct()) answer += i;
            return answer;
        }
        public static int Problem33()
        {
            int num = 0;
            int[,] fractions = new int[4, 2];
            for (double a = 1; a < 10; a++)
            {
                for (double b = 1; b < 10; b++)
                {
                    for (double c = 1; c < 10; c++)
                    {
                        for (double d = 1; d < 10; d++)
                        {
                            double e = (10 * a + b) / (10 * c + d);
                            if (e < 1 && ((e == a / c && b == d) || (e == a / d && b == c) || (e == b / c && a == d) || (e == b / d && a == c)))
                            {

                                fractions[num, 0] = (int)(10 * a + b);
                                fractions[num, 1] = (int)(10 * c + d);
                                num++;
                            }
                        }
                    }
                }
            }
            int numerator = fractions[0, 0] * fractions[1, 0] * fractions[2, 0] * fractions[3, 0];
            int denominator = fractions[0, 1] * fractions[1, 1] * fractions[2, 1] * fractions[3, 1];
            denominator /= UsefulTools.Gcf(numerator, denominator);
            return denominator;
        }
        public static int Problem34()
        {
            int answer = 0, sum;
            for (int i = 10; i < 600000; i++)
            {
                sum = 0;
                int j = i;
                while (j > 0)
                {
                    sum += UsefulTools.Factorial(j % 10);
                    j /= 10;
                }
                if (sum == i) answer += i;
            }
            return answer;
        }
        public static int Problem35()
        {
            int answer = 0;
            for (int i = 2; i < 1000000; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    bool is_prime = true;
                    int num_of_digits = (int)Math.Floor(Math.Log10(i) + 1);
                    int j = i;
                    do
                    {
                        int k = j % 10;
                        j /= 10;
                        j += k * (int)Math.Pow(10, num_of_digits - 1);
                        if (!UsefulTools.IsPrime(j)) is_prime = false;
                    } while (j != i);
                    if (is_prime) answer++;
                }
            }
            return answer;
        }
        public static int Problem36()
        {
            var answer = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if (i % 10 == 0 | i % 2 == 0) continue;
                if (UsefulTools.IsPalindrome(i) && UsefulTools.IsPalindromeString(Convert.ToString(i, 2))) answer += i;
            }
            return answer;
        }
        public static int Problem37()
        {
            int answer = 0;
            for (int i = 10, j = 0; j < 11; i++)
            {
                if (UsefulTools.IsPrime(i))
                {
                    int k = i, l = 1;
                    while (k > 0)
                    {
                        k /= 10;
                        int m = i - (int)(k * Math.Pow(10, l));
                        if (!(UsefulTools.IsPrime(k) && UsefulTools.IsPrime(m))) break;
                        l++;
                    }
                    if (l == Math.Floor(Math.Log10(i) + 1))
                    {
                        answer += i;
                        j++;
                    }
                }
            }
            return answer;
        }
        public static int Problem38()
        {
            int answer = 0;
            static int ToPandigital_maxsize9(int number, int max_multiple)
            {
                string temp = "";
                for (int i = 0; i < max_multiple; i++)
                {
                    temp += (number * (i + 1)).ToString();
                }
                if (temp.Length > 9 || !UsefulTools.IsPandigital(Convert.ToInt32(temp))) return 0;
                return Convert.ToInt32(temp);
            }
            for (int i = 2; i < 20; i++)
            {
                for (int j = 1; j < 50000; j++)
                {
                    int k = ToPandigital_maxsize9(j, i);
                    if (k > answer) answer = k;
                }
            }
            return answer;
        }
        public static int Problem39()
        {
            static bool IsRightTriangle(int a, int b, int c)
            {
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) return true;
                return false;
            }
            int answer = 0, value = 0;
            for (int i = 1; i <= 1000; i++)
            {
                int temp_value = 0;
                for (int a = 1; a < i / 2; a++)
                {
                    for (int b = 1; b < i / 2; b++)
                    {
                        int c = i - (a + b);
                        if (a >= b && a >= c && IsRightTriangle(b, c, a)) temp_value++;
                        if (b >= a && b >= c && IsRightTriangle(a, c, b)) temp_value++;
                        if (c >= b && c >= a && IsRightTriangle(b, a, c)) temp_value++;
                    }
                }
                if (temp_value > value)
                {
                    value = temp_value;
                    answer = i;
                }
            }
            return answer;
        }
        public static int Problem40()
        {
            int answer = 1, temp = 1;
            string s = "0";
            while (s.Length < 1000001)
            {
                s += temp.ToString();
                temp++;
            }
            answer *= (s[1] - 48) * (s[10] - 48) * (s[100] - 48) * (s[1000] - 48) * (s[10000] - 48) * (s[100000] - 48) * (s[1000000] - 48);
            return answer;
        }
        public static int Problem41()
        {
            int answer = 0;
            int i = 1000000000;
            while (i > 0)
            {
                if (UsefulTools.IsPandigital(i) && UsefulTools.IsPrime(i))
                {
                    answer = i;
                    break;
                }
                i--;
            }
            return answer;
        }
        public static int Problem42()
        {
            static bool IsTriangular(int i)
            {
                for (int j = 1; j < 2 * i; j++)
                {
                    if (j * (j + 1) == 2 * i) return true;
                }
                return false;
            }
            string text;
            using (StreamReader sr = new(_path))
            {
                text = sr.ReadToEnd();
            }
            int value = 0, answer = 0;
            foreach (char c in text)
            {
                if (c == '"' && value > 0)
                {
                    if (IsTriangular(value)) answer++;
                    value = 0;
                }
                else if (Char.IsLetter(c)) value += Convert.ToInt16(c) - 64;
            }
            return answer;
        }
        public static int Problem44()
        {
            List<int> pentagonal = new();
            var i = 1;
            var distance = int.MaxValue;
            while (3 * i + 1 < distance)
            {
                var new_pentagonal = i * (3 * i - 1) / 2;
                foreach (var a in pentagonal)
                {
                    if(pentagonal.Contains(new_pentagonal-a))
                    {
                        var b = 2*a<new_pentagonal?new_pentagonal-2*a:new_pentagonal-2*a;
                        if (pentagonal.Contains(b) && b < distance)
                        {
                            Console.WriteLine($"a: {a} b: {b} a+b: {a + b}");
                            distance = b;
                        }
                    }
                }
                pentagonal.Add(new_pentagonal);
                if (i % 1000 == 0) Console.WriteLine(i);
                i++;
            }
            return distance;
        }
    public static int Problem46()
    {
        bool a = true;
        int answer = 3;
        while (a)
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
        return answer - 1;
    }
    public static int Problem47()
    {
        static int PrmFacNum(int num)
        {
            return UsefulTools.Prime_factors(num).Length;
        }
        int i = 2;
        while (true)
        {
            if (PrmFacNum(i) == 4 && PrmFacNum(i + 1) == 4 && PrmFacNum(i + 2) == 4 && PrmFacNum(i + 3) == 4)
            {
                return i;
            }
            i++;
        }
    }
    public static string Problem49()
    {
        string ans = "";
        for (int i = 1000; i <= 9999; i++)
        {
            if (UsefulTools.IsPrime(i))
            {
                for (int j = 1; j < 8999; j++)
                {
                    if (UsefulTools.IsPrime(i + j) && UsefulTools.IsPrime(i + 2 * j) && UsefulTools.IsPermutation(i, i + j) && UsefulTools.IsPermutation(i, i + 2 * j)) ans += i.ToString() + (i + j).ToString() + (i + 2 * j).ToString() + '\n';
                }
            }
        }
        return ans;
    }
    public static int Problem51()
    {

        List<int> Familly(int[] digits, int starting_pos)
        {
            List<int> familly = new List<int>();
            int size = 0;
            int starting_digit = 0;
            int length = digits.Length;
            if (starting_pos < length)
            {
                int[] new_digits = new int[length];
                for (int i = 0; i < length; i++) new_digits[i] = digits[i];
                new_digits[starting_pos++] = -1;

                if (new_digits[0] == -1) starting_digit = 1;
                for (int j = starting_digit; j < 10; j++)
                {
                    int[] digits2 = new int[length];
                    for (int k = 0; k < length; k++)
                    {
                        if (new_digits[k] == -1) digits2[k] = j;
                        else digits2[k] = new_digits[k];
                    }
                    int value = UsefulTools.DigitsToNum(digits2);
                    if (UsefulTools.IsPrime(value))
                    {
                        familly.Add(value);
                    }
                }
                if (Familly(digits, starting_pos).Count > familly.Count) familly = new List<int>(Familly(digits, starting_pos));
                if (Familly(new_digits, starting_pos).Count > familly.Count) familly = new List<int>(Familly(new_digits, starting_pos));
            }
            return familly;
        }

        int num = 10;
        while (true)
        {
            if (UsefulTools.IsPrime(num) && (Familly(UsefulTools.DigitsOfNum(num), 0).Count == 8) && Familly(UsefulTools.DigitsOfNum(num), 0).Contains(num)) return num;
            num++;
        }
    }
    public static int Problem52()
    {
        bool IsSameDigitMultiple(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (!IsSameDigit(nums[i], nums[j])) return false;
                }
            }
            return true;
        }
        bool IsSameDigit(int num1, int num2)
        {
            int[] digits1 = UsefulTools.DigitsOfNum(num1);
            int[] digits2 = UsefulTools.DigitsOfNum(num2);
            if (Math.Floor(Math.Log10(num1)) != Math.Floor(Math.Log10(num2))) return false;
            foreach (int digit in digits1) if (!digits2.Contains(digit)) return false;
            return true;
        }
        int i = 1;
        while (true)
        {
            int[] digits = { i, 2 * i, 3 * i, 4 * i, 5 * i, 6 * i };
            if (IsSameDigitMultiple(digits)) return i;
            i++;
        }
    }
    public static int Problem55()
    {
        int answ = 0;
        BigInteger ReverseNum(BigInteger x)
        {
            BigInteger y = 0, xsize = (int)Math.Floor(Math.Log10((double)x) + 1);
            while (x > 0)
            {
                y += (BigInteger)Math.Pow(10, (double)xsize - 1) * (x % 10);
                xsize--;
                x /= 10;
            }
            return y;
        }
        for (int i = 1; i < 10000; i++)
        {
            int n = 0;
            BigInteger num = i;
            do
            {
                num += ReverseNum(num);
                n++;
            } while (n < 50 && !UsefulTools.IsPalindrome(num));
            if (n == 50) answ++;
        }
        return answ;
    }
    public static int Problem58()
    {
        int num_of_primes_diagonal = 3, start = 3;
        while ((double)num_of_primes_diagonal / (start * 2 - 1) >= 0.1)
        {
            int first_num = (int)Math.Pow(start, 2) + 1;
            if (UsefulTools.IsPrime(first_num + start)) num_of_primes_diagonal++;
            if (UsefulTools.IsPrime(first_num + (start * 2) + 1)) num_of_primes_diagonal++;
            if (UsefulTools.IsPrime(first_num + (start * 3) + 2)) num_of_primes_diagonal++;
            start += 2;
        }
        return start;
    }


    public static int Problem60()
    {
        PrimeChecker primeChecker = new();
        bool AreConcatenaintable(BigInteger prime1, BigInteger prime2)
        {
            if (!primeChecker.IsPrime((BigInteger.Pow(10, (int)(BigInteger.Log10(prime2) + 1))) * prime1 + prime2)) return false;
            if (!primeChecker.IsPrime((BigInteger.Pow(10, (int)(BigInteger.Log10(prime1) + 1))) * prime2 + prime1)) return false;
            return true;
        }
        Graph<int> graph = new();
        int i = 3, answer = int.MaxValue / 2;
        while (i < (answer + 12))
        {
            if (primeChecker.IsPrime(i))
            {
                Vertex<int> new_vertex = new(i);
                List<Vertex<int>> neighbours = new();
                foreach (Vertex<int> v in graph.Vertices)
                {
                    if (AreConcatenaintable(i, v.Value)) neighbours.Add(v);
                }
                new_vertex.AddNeighbours(neighbours);
                graph.AddVertex(new_vertex);
                foreach (Vertex<int> v in neighbours) v.AddNeighbour(new_vertex);
                List<List<Vertex<int>>> cliques = graph.FindCliques(5);
                if (cliques.Count > 0)
                {
                    foreach (List<Vertex<int>> clique in cliques)
                    {
                        int sum = 0;
                        foreach (Vertex<int> v in clique)
                        {
                            sum += v.Value;
                        }
                        if (sum < answer) answer = sum;
                    }
                }
            }
            i++;
        }
        return (int)answer;
    }
    public static string Problem67()
    {
        return Problem18();
    }
    public static int Problem92()
    {
        int count = 0;
        static int SquareOfDigits(int x)
        {
            int sum = 0;
            while (x > 0)
            {
                sum += (x % 10) * (x % 10);
                x /= 10;
            }
            return sum;
        }
        for (int i = 2; i < 10000000; i++)
        {
            int x = i;
            while (x != 1 && x != 89) x = SquareOfDigits(x);
            if (x == 89) count++;
        }
        return count;
    }
    /* public static int Problem834() //unsolved
     {
         static BigInteger SequenceValue(BigInteger m, BigInteger n) => ((m + 1) * (2*n + m))/2;
         static BigInteger SumT(BigInteger n)
         {
             string s = n.ToString() + ":";
             var sum = 0;
             for (var i = 1; i <= n * (n - 2); i++) if (SequenceValue(i, n) % (i + n) == 0)
                 {
                     s += " " + i.ToString();
                     sum += i;
                 }
             Console.WriteLine(s);
             return sum;
         }
         var sum = 0;
         for (var i = 3; i <= 1234567; i++) sum += (int)SumT(i);
         return sum;
     }*/
    public static string Problem836()
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

