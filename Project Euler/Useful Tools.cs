using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public static class UsefulTools
    {
        public static string HTMLText(int problemNumber)
        {
            var wc = new WebClient();
            var raw = wc.DownloadData($"https://projecteuler.net/problem={problemNumber}");
            return System.Text.Encoding.UTF8.GetString(raw);
        }
        public static string ProblemText(int problemNumber)
        {

            static string HtmlToPlainText(string html)
            {
                const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
                const string stripFormatting = @"<[^>]*(>|$)";
                const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";
                var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
                var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
                var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);
                var text = html;
                text = WebUtility.HtmlDecode(text);
                text = tagWhiteSpaceRegex.Replace(text, "><");
                text = lineBreakRegex.Replace(text, Environment.NewLine);
                text = stripFormattingRegex.Replace(text, string.Empty);
                return text;
            }
            var pureText = HtmlToPlainText(HTMLText(problemNumber));
            var startingText = $"Problem {problemNumber}";
            var startIndex = pureText.IndexOf(startingText, StringComparison.Ordinal);
            var endIndex = pureText.IndexOf("Project Euler:", StringComparison.Ordinal);
            var startingLength = startingText.Length;
            var problemText = pureText.Substring(startIndex + startingLength, endIndex - startIndex - startingLength - 3);
            return ($"\nProblem number {problemNumber}:\n{problemText}");
        }
        public static BigInteger BinomialCooficient(BigInteger top, BigInteger bottom)
        {
            BigInteger answer = 1;
            if (bottom > top) return 0;
            for (BigInteger d = 1; d <= bottom; d++)
            {
                answer *= top--;
                answer /= d;
            }
            return answer;
        }
        public static bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (var i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
        public static bool IsPrime(ulong x, List<ulong> primes)
        {
            if (x < 2) return false;
            foreach (var prime in primes)
            {
                if (prime > Math.Sqrt(x)) break;
                if (x % prime == 0) return false;
            }
            return true;
        }
        public static bool IsPrime(double x)
        {
            if (x < 2) return false;
            for (var i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
        public static int NumberOfDivisors(int x)
        {
            var divisorsNumber = 2;
            for (var i = 2; i < Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    divisorsNumber += 2;
            }

            if (x % Math.Sqrt(x) == 0)
                divisorsNumber += 1;
            return divisorsNumber;
        }
        public static int SumOfProperDivisors(int x)
        {
            var sum = 1;
            if (x % Math.Sqrt(x) == 0) sum += Convert.ToInt32(Math.Sqrt(x));
            for (var i = 2; i < Math.Sqrt(x); i++)
            {
                if (x % i != 0) continue;
                sum += i;
                sum += x / i;
            }
            return sum;
        }
        public static bool IsPalindrome(int x)
        {
            long original = x, reverse = 0;
            while (x != 0)
            {
                var rem = x % 10;
                reverse = reverse * 10 + rem;
                x /= 10;
            }
            return original == reverse;
        }
        public static bool IsPalindrome(BigInteger x)
        {
            BigInteger original = x, reverse = 0;
            while (x != 0)
            {
                var rem = x % 10;
                reverse = reverse * 10 + rem;
                x /= 10;
            }
            return original == reverse;
        }

        public static string NumberToWords(int x)
        {
            if (x > 9999 | x < 0)
                return "number not supported";
            string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            var words = "";
            if (x > 999)
                words += $"{units[x / 1000]} Thousand";
            if (x > 99 && x % 1000 - x % 100 != 0)
            {
                words += $" {units[x % 1000 / 100]} Hundred";
                if (x % 100 != 0)
                    words += " And";
            }
            if (x > 19)
                words += $" {tens[x % 100 / 10]}";
            if (x % 100 < 20 && x % 100 > 10)
                words += $" {units[x % 20]}";
            if (x > 0 && x % 100 < 10 | x % 100 > 20)
                words += $" {units[x % 10]}";
            if (x % 100 == 10)
                words += " Ten";
            if (x == 0)
                return "Zero";
            return words;
        }

        public static int Gcf(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int Lcm(int a, int b)
        {
            return (a / Gcf(a, b)) * b;
        }
        public static int[] DigitsOfNum(int num)
        {
            int[] digits = new int[(int)Math.Floor(Math.Log10(num) + 1)];
            int i = 1;
            while (num != 0)
            {
                digits[digits.Length - i] = num % 10;
                i++;
                num = num / 10;
            }
            return digits;
        }
        public static int[] DigitsOfNum(BigInteger num)
        {
            int[] digits = new int[(int)Math.Floor(BigInteger.Log10(num) + 1)];
            int i = 1;
            while (num != 0)
            {
                digits[digits.Length - i] = (int)(num % 10);
                i++;
                num = num / 10;
            }
            return digits;
        }
        public static bool IsPermutation(int x, int y)
        {
            int[] digitsX = DigitsOfNum(x);
            int[] digitsY = DigitsOfNum(y);
            if (digitsX.Length != digitsY.Length) return false;
            for (int i = 0; i < digitsX.Length; i++)
            {
                if (!digitsY.Contains(digitsX[i])) return false;
                if (!digitsX.Contains(digitsY[i])) return false;
            }
            return true;
        }
        public static ulong DigitsToNum(int[] digits)
        {
            ulong num = 0;
            for (int i = 0; i < digits.Length; i++) num += (ulong)digits[digits.Length - i - 1] * (ulong)Math.Pow(10, i);
            return num;
        }

        public static int Factorial(int x)
        {
            if (x == 0) return 1;
            for (var i = x - 1; i > 0; i--)
            {
                x *= i;
            }
            return x;
        }
        public static bool IsPandigital(int number)
        {
            var digits = DigitsOfNum(number);
            if (digits.Length > 9) return false;
            for (int i = 0; i < digits.Length; i++) if (!digits.Contains(i+1)) return false;
            return true;
        }
        public static int[] Prime_factors(int x)
        {
            if (x <= 0) return null;
            if (x == 1)
            {
                int[] result = { 1 };
                return result;
            }
            List<int> list = new();
            if (x % 2 == 0)
            {
                list.Add(2);
                while (x % 2 == 0)
                {
                    x /= 2;
                }
            }
            for (int i = 3; i <= Math.Sqrt(x); i += 2)
            {
                while (x % i == 0)
                {
                    list.Add(i);
                    x /= i;
                }
            }
            if (x > 2) list.Add(x);
            return list.Distinct().ToArray();
        }
        public static double[] Prime_factors(double x)
        {
            if (x <= 0) return null;
            if (x == 1)
            {
                double[] result = { 1 };
                return result;
            }
            List<double> list = new();
            if (x % 2 == 0)
            {
                list.Add(2);
                while (x % 2 == 0)
                {
                    x /= 2;
                }
            }
            for (int i = 3; i <= Math.Sqrt(x); i += 2)
            {
                while (x % i == 0)
                {
                    list.Add(i);
                    x /= i;
                }
            }
            if (x > 2) list.Add(x);
            return list.Distinct().ToArray();
        }

        private static long[,] EfficiencyTest(int numberOfProblems)
        {
            var allTimes = new long[numberOfProblems, 2];
            var stopwatch = new Stopwatch();
            for (var i = 1; i <= numberOfProblems; i++)
            {
                stopwatch.Reset();
                stopwatch.Start();
                ProblemRunner.ChosenProblem(i, false, false);
                stopwatch.Stop();
                allTimes[i - 1, 1] = i;
                allTimes[i - 1, 0] = stopwatch.ElapsedMilliseconds;
                if (ProblemRunner.ChosenProblemNumber != i)
                {
                    allTimes[i - 1, 0] = -1;
                }
                Console.Write("\r{0}   ", $"Progress: {i}/{numberOfProblems}");
            }

            var n = numberOfProblems;
            while (n > 0)
            {

                for (var i = 0; i < n - 1; i++)
                {
                    if (allTimes[i, 0] <= allTimes[i + 1, 0]) continue;
                    (allTimes[i, 0], allTimes[i + 1, 0]) = (allTimes[i + 1, 0], allTimes[i, 0]);
                    (allTimes[i, 1], allTimes[i + 1, 1]) = (allTimes[i + 1, 1], allTimes[i, 1]);
                }
                n--;
            }

            return allTimes;
        }
        public static void EfficiencyTestToFile(int numberOfProblems)
        {
            var timesTable = EfficiencyTest(numberOfProblems);
            using var sw = new StreamWriter($@"{Environment.CurrentDirectory}..\..\..\..\EfficiencyTest.txt");
            for (var i = numberOfProblems - 1; i >= 0; i--)
            {
                switch (timesTable[i, 0])
                {
                    case -1:
                        sw.WriteLine($"Problem {timesTable[i, 1]} not solved yet");
                        break;
                    case < 1:
                        sw.WriteLine($"Problem {timesTable[i, 1]} - less than one milisecond");
                        break;
                    case > 1:
                        sw.WriteLine($"Problem {timesTable[i, 1]} - {timesTable[i, 0]} miliseconds");
                        break;
                    case 1:
                        sw.WriteLine($"Problem {timesTable[i, 1]} - 1 milisecond");
                        break;
                }
            }
        }
        public static int NumOfDigits(int x)
        {
            return (int)Math.Floor(Math.Log10(x) + 1);
        }

        public static void EfficiencyTestTop(int numberOfProblems, int howManyTop)
        {
            var timesTable = EfficiencyTest(numberOfProblems);
            for (var i = numberOfProblems - 1; i >= numberOfProblems - howManyTop; i--)
            {
                Console.WriteLine($"\nProblem {timesTable[i, 1]} Time: {timesTable[i, 0]}");
            }
        }
        public static string TimeConversion(TimeSpan x)
        {
            var minimum = new TimeSpan(0, 0, 0, 0, 1);
            var timeSpent = "";
            if (x.Days > 0) timeSpent += $"{x.Days} days ";
            if (x.Days == 1) timeSpent += $"1 day ";
            if (x.Hours > 0) timeSpent += $"{x.Hours} hours ";
            if (x.Hours == 1) timeSpent += $"1 hour ";
            if (x.Minutes > 0) timeSpent += $"{x.Minutes} minutes ";
            if (x.Seconds > 1) timeSpent += $"{x.Seconds} seconds and ";
            if (x.Seconds == 1) timeSpent += $"1 second and ";
            if (x.Milliseconds > 1) timeSpent += $"{x.Milliseconds} miliseconds";
            if (x.Milliseconds == 1) timeSpent += $"1 milisecond";
            if (x > minimum)
            {
                return $"Solution took {timeSpent}.";
            }
            return "Solution took less than 1 milisecond!";
        }
        public static bool IsPalindromeString(string x)
        {
            for (int i = 0; i < x.Length / 2; i++)
            {
                if (x[i] != x[x.Length - i - 1]) return false;
            }
            return true;
        }
        public static void WriteOutSolved()
        {
            Console.WriteLine("Wait while the problems are being checked...");
            int howmany = 0;
            for (int i = 0; i < 300; i++)
            {
                if (ProblemRunner.DoesProblemExist(i)) howmany++;
            }
            int[] solved = new int[howmany];
            int index = 0;
            for (int i = 1; i < 300; i++)
            {
                if (ProblemRunner.DoesProblemExist(i)) solved[index++] = i;
            }
            Console.Write($"\n\nThere are {howmany} problems solved: ");
            int x = 0;
            for (int i = 0; i < howmany; i++)
            {
                if (i != howmany - 1 && (solved[i + 1] == solved[i] + 1))
                {
                    if (x == 0)
                    {
                        Console.Write($"{solved[i]}-");
                        x = 1;
                    }
                }
                else if (i != howmany - 1)
                {
                    Console.Write($"{solved[i]},");
                    x = 0;
                }
                else Console.Write($"{solved[i]}\n\n");
            }
        }
        static void Swap(ref int a, ref int b) => (b, a) = (a, b);
        static void GetPandigitalNums(int[] digits, int k, int m, ref List<ulong> pandigitals)
        {
            if (k == m && DigitsToNum(digits).ToString().Length==m+1)
            {
                pandigitals.Add(DigitsToNum(digits));
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref digits[k], ref digits[i]);
                    GetPandigitalNums(digits, k + 1, m, ref pandigitals);
                    Swap(ref digits[k], ref digits[i]);
                }
            }
        }

        public static List<ulong> PandigitalNumsDescending(int size, int start)
        {
            if (size+start > 10) return new();
            int[] digits = new int[size];
            for (int i = 0; i < size; i++) digits[i] = i + start;
            List<ulong> pandigitals = new();
            GetPandigitalNums(digits, 0, size - 1, ref pandigitals);
            pandigitals.Sort();
            pandigitals.Reverse();
            return pandigitals;
        }
    }
    class Graph<T>
    {
        private readonly List<Vertex<T>> vertices;
        public Graph() => vertices = new List<Vertex<T>>();

        public void AddVertex(Vertex<T> vertex) => vertices.Add(vertex);

        public int Size => vertices.Count;
        public List<List<Vertex<T>>> FindCliques(int size)
        {
            var cliques = new List<List<Vertex<T>>>();
            var verticesCopy = new List<Vertex<T>>(vertices);
            while (verticesCopy.Count > 0)
            {
                var vertex = verticesCopy[0];
                if (vertex.Degree < size - 1)
                {
                    verticesCopy.Remove(vertex);
                    continue;
                }
                var neighbours = vertex.Neighbours;
                var clique = new List<Vertex<T>> { vertex };
                foreach (var neighbour in neighbours)
                {
                    if (neighbour.Degree >= size - 1)
                    {
                        var isClique = true;
                        foreach (var v in clique) if (v | neighbour) isClique = false;
                        if (isClique) clique.Add(neighbour);
                    }
                }
                if (clique.Count >= size) cliques.Add(clique);
                verticesCopy.Remove(vertex);
            }
            return cliques;
        }
        public Vertex<T> FindVertex(T value)
        {
            return vertices.Find(v => v.Value.Equals(value));
        }
        public List<Vertex<T>> Vertices => vertices;
    }
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbours { get; set; }
        public Vertex(T value, List<Vertex<T>> neighbours, params Vertex<T>[] parameters) : this(value, (IEnumerable<Vertex<T>>)parameters) { }
        public Vertex(T value, IEnumerable<Vertex<T>> neighboursArray = null)
        {
            Value = value;
            Neighbours = neighboursArray?.ToList() ?? new List<Vertex<T>>();
        }
        public void AddNeighbour(Vertex<T> neighbour) => Neighbours.Add(neighbour);
        public void AddNeighbours(params Vertex<T>[] neighbours) => Neighbours.AddRange(neighbours);
        public void AddNeighbours(IEnumerable<Vertex<T>> neighbours) => Neighbours.AddRange(neighbours);
        public void RemoveNeighbour(Vertex<T> neighbour) => Neighbours.Remove(neighbour);
        public int Degree => Neighbours.Count;
        public override string ToString() => Neighbours.Aggregate(new StringBuilder($"{Value}: "), (sb, v) => sb.Append($"{v.Value}, ")).ToString();
        public static bool operator &(Vertex<T> a, Vertex<T> b) => a.Neighbours.Contains(b);
        public static bool operator |(Vertex<T> a, Vertex<T> b) => !(a & b);
    }
    class PrimeChecker
    {
        List<byte> Primes_byte;
        List<ushort> Primes_short;
        List<uint> Primes_int;
        List<ulong> Primes_long;
        List<BigInteger> Primes_big;
        bool use_byte = false;
        bool use_short = false;
        bool use_int = false;
        bool use_long = false;
        bool use_big = false;
        public PrimeChecker() : this(new List<byte> { 2, 3 }) { }
        public PrimeChecker(List<byte> primes)
        {
            Primes_byte = primes;
            use_byte = true;
        }
        public PrimeChecker(List<ushort> primes)
        {
            Primes_short = primes;
            use_short = true;
        }
        public PrimeChecker(List<uint> primes)
        {
            Primes_int = primes;
            use_int = true;
        }
        public PrimeChecker(List<ulong> primes)
        {
            Primes_long = primes;
            use_long = true;
        }
        public PrimeChecker(List<BigInteger> primes)
        {
            Primes_big = primes;
            use_big = true;
        }

        public bool IsPrime(BigInteger x)
        { 
            if(x< 2) return false;
            ChangeSizeIfNecessery(x);
            BigInteger sqrt = Sqrt(x);
            if (use_byte) return PrimeCheck_byte((byte)sqrt, (byte)x);
            if (use_short) return PrimeCheck_short((ushort)sqrt, (ushort)x);
            if (use_int) return PrimeCheck_int((uint)sqrt, (uint)x);
            if (use_long) return PrimeCheck_long((ulong)sqrt, (ulong)x);
            if (use_big) return PrimeCheck_big(sqrt, x);
            
            return true;
        }
        bool PrimeCheck_byte(byte sqrt, byte x)
        {
            foreach (var prime in Primes_byte)
            {
                if (prime > sqrt) break;
                if (x % prime == 0) return false;
            }
            if (Primes_byte.Last() < sqrt)
            {
                for (byte i = (byte)(Primes_byte.Last() + 2); i <= sqrt; i += 2)
                {
                    if (IsPrime(i))
                    {
                        Primes_byte.Add(i);
                        if (x % i == 0) return false;
                    }
                }
            }
            return true;
        }
        bool PrimeCheck_short(ushort sqrt, ushort x)
        {
            foreach (var prime in Primes_short)
            {
                if (prime > sqrt) break;
                if (x % prime == 0) return false;
            }
            if (Primes_short.Last() < sqrt)
            {
                for (ushort i = (ushort)(Primes_short.Last() + 2); i <= sqrt; i += 2)
                {
                    if (IsPrime(i))
                    {
                        Primes_short.Add(i);
                        if (x % i == 0) return false;
                    }
                }
            }
            return true;
        }
        bool PrimeCheck_int(uint sqrt, uint x)
        {
            foreach (var prime in Primes_int)
            {
                if (prime > sqrt) break;
                if (x % prime == 0) return false;
            }
            if (Primes_int.Last() < sqrt)
            {
                for (uint i = (uint)(Primes_int.Last() + 2); i <= sqrt; i += 2)
                {
                    if (IsPrime(i))
                    {
                        Primes_int.Add(i);
                        if (x % i == 0) return false;
                    }
                }
            }
            return true;
        }
        bool PrimeCheck_long(ulong sqrt, ulong x)
        {
            foreach (var prime in Primes_long)
            {
                if (prime > sqrt) break;
                if (x % prime == 0) return false;
            }
            if (Primes_long.Last() < sqrt)
            {
                for (ulong i = (ulong)(Primes_long.Last() + 2); i <= sqrt; i += 2)
                {
                    if (IsPrime(i))
                    {
                        Primes_long.Add(i);
                        if (x % i == 0) return false;
                    }
                }
            }
            return true;
        }
        bool PrimeCheck_big(BigInteger sqrt, BigInteger x)
        {
            foreach (var prime in Primes_big)
            {
                if (prime > sqrt) break;
                if (x % prime == 0) return false;
            }
            if (Primes_big.Last() < sqrt)
            {
                for (BigInteger i = Primes_big.Last() + 2; i <= sqrt; i += 2)
                {
                    if (IsPrime(i))
                    {
                        Primes_big.Add(i);
                        if (x % i == 0) return false;
                    }
                }
            }
            return true;
        }
        static BigInteger Sqrt(BigInteger x)
        {
            if (x == 0) return 0;
            if (x < 0) throw new ArithmeticException("NaN");
            var n = (x >> 1) + 1;
            var n1 = (n + (x / n)) >> 1;
            while (n1 < n)
            {
                n = n1;
                n1 = (n + (x / n)) >> 1;
            }
            return n;
        }
        void ChangeSizeIfNecessery(BigInteger x)
        {
            if (use_big) return;
            if (use_byte)
            {
                if (x > byte.MaxValue)
                {
                    use_byte = false;
                    use_short = true;
                    Primes_short = new List<ushort>(Primes_byte.Select(b => (ushort)b));
                    Primes_byte = null;
                }
            }
            if (use_short)
            {
                if (x > ushort.MaxValue)
                {
                    use_short = false;
                    use_int = true;
                    Primes_int = new List<uint>(Primes_short.Select(b => (uint)b));
                    Primes_short = null;
                }
            }
            if (use_int)
            {
                if (x > uint.MaxValue)
                {
                    use_int = false;
                    use_long = true;
                    Primes_long = new List<ulong>(Primes_int.Select(b => (ulong)b));
                    Primes_int = null;
                }
            }
            if (use_long)
            {
                if (x > ulong.MaxValue)
                {
                    use_long = false;
                    use_big = true;
                    Primes_big = new List<BigInteger>(Primes_long.Select(b => (BigInteger)b));
                    Primes_big = null;
                }
            }
        }
    }
}