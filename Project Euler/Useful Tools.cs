using System;
using System.Net;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public static class UsefulTools
    {
        [Obsolete("Obsolete")]
        public static string ProblemText(int problemNumber)
        {
            var wc = new WebClient();
            var raw = wc.DownloadData($"https://projecteuler.net/problem={problemNumber}");
            var webData = System.Text.Encoding.UTF8.GetString(raw);
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
            var pureText = HtmlToPlainText(webData);
            var startingText = $"Problem {problemNumber}";
            var startIndex = pureText.IndexOf(startingText, StringComparison.Ordinal);
            var endIndex = pureText.IndexOf("Project Euler:", StringComparison.Ordinal);
            var startingLength = startingText.Length;
            var problemText = pureText.Substring(startIndex + startingLength, endIndex - startIndex - startingLength - 3);
            return ($"\nProblem number {problemNumber}:\n{problemText}");
        }

        public static long BinomialCooficient(long top, long bottom)
        {
            long answer = 1;
            if (bottom > top) return 0;
            for (long d = 1; d <= bottom; d++)
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
            int original = x, reverse = 0;
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

        private static int Gcf(int a, int b)
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

        public static int Factorial(int x)
        {
            if (x == 0) return 1;
            for (var i = x - 1; i > 0; i--)
            {
                x *= i;
            }
            return x;
        }
    }
}