using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Security.Cryptography;
using NUnit.Framework.Internal;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal static class Program
    {
        internal static void Main()
        {
            Assert.AreEqual("", Kata.UniqueInOrder(""));
            Assert.AreEqual("ABCDAB", Kata.UniqueInOrder("AAAABBBCCDAABBB"));
            Console.WriteLine("Well done!");
            Console.ReadKey();
        }
    }
    internal static class Kata
    {
        public static int FindEvenIndex(int[] arr)
        {
            int evenIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if(GetLeftSum(arr, i) == GetRightSum(arr, i))
                {
                    evenIndex = i;
                    break;
                }
            }
            return evenIndex;
        }
        public static int GetLeftSum(int[] arr, int currentIndex)
        {
            int result = 0;
            if (currentIndex == 0)
            {
                result = 0;
            }
            else
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    result += arr[i];
                }
            }
            return result;
        }
        public static int GetRightSum(int[] arr, int currentIndex)
        {
            int result = 0;
            if (currentIndex == arr.Length)
            {
                result = 0;
            }
            else
            {
                for (int i = currentIndex + 1; i < arr.Length; i++)
                {
                    result += arr[i];
                }
            }
            return result;
        }
        public static int SquareDigits(int n)
        {
            string input = n.ToString();
            string output = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char digit = input[i];
                int square = Int32.Parse(digit.ToString()) * Int32.Parse(digit.ToString());
                output += square.ToString();
            }
            return Int32.Parse(output);
        }
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][0] >= 55 && data[i][1] > 7) result.Add("Senior");
                else result.Add("Open");
            }
            return result;
        }
        public static int Solution(int value)
        {
            int cnt = 0;
            int sum = 0;
            for (int i = 0; i < value; i++)
            {
                if(i % 3 == 0 && i % 5 == 0 && cnt == 0)
                {
                    cnt++;
                    sum += i;
                }
                else if (i % 3 == 0)
                {
                    sum += i;
                }
                else if(i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        public static string ToCamelCase(string str)
        {
            // why this code perfectly work at my PC, but don`t work on site?

            //string[] words;
            //if(str.Contains('-')) words = str.Split('-');
            //else words = str.Split('_');
            //str = words[0];
            //for (int i = 1; i < words.Length; i++)
            //{
            //    str += char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            //}

            const string pattern = "[-_]";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                string[] words = Regex.Split(str, pattern);
                str = words[0];
                for (int i = 1; i < words.Length; i++)
                {
                    str += char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return str;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                int match = 0;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j]) match++;
                }
                if (match == 0) result.Add(a[i]);
            }
            return result.ToArray();
        }
        public static string Tickets(int[] peopleInLine)
        {
            string result = "YES";

            int bill25 = 0;
            int bill50 = 0;
            int bill100 = 0;

            foreach(int human in peopleInLine)
            {
                if (human / 25 == 1)
                {
                    bill25++;
                }
                else if (human / 50 == 1 && bill25 -1 >= 0)
                {
                    bill50++;
                    bill25--;
                }
                else if (human / 100 == 1)
                {
                    if(bill50 - 1 >= 0 && bill25 - 1 >= 0)
                    {
                        bill50--;
                        bill25--;
                        bill100++;
                    }
                    else if(bill25 - 3 >= 0)
                    {
                        bill25 -= 3;
                        bill100++;
                    }
                    else
                    {
                        result = "NO";
                        break;
                    }
                }
                else
                {
                    result = "NO";
                    break;
                }
            }

            return result;
        }
        public static string RomanConvert(int n)
        {
            string result = "";

            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            if(n >= 4000)
            {
                int intResult = n / 1000;
                n %= 1000;
                return RomanConvert(intResult) + RomanConvert(n);
            }
            else
            {
                int intResult = n / 1000;
                n %= 1000;
                result += thousands[intResult];

                intResult = n / 100;
                n %= 100;
                result += hundreds[intResult];

                intResult = n / 10;
                n %= 10;
                result += tens[intResult] + ones[n];
            }
            return result;
        }
        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0)
                return new double[] { 0 };
            else
                return Tribonacci(signature).Take(n).ToArray();
        }
        public static IEnumerable<double> Tribonacci(double[] signature)
        {
            foreach (var n in signature)
                yield return n;

            var buffer = new Queue<double>(signature);
            while (true)
            {
                var next = buffer.Sum();
                yield return next;
                buffer.Dequeue();
                buffer.Enqueue(next);
            }
        }
        public static int Test(string numbers)
        {
            List<string> digits = numbers.Split(" ").ToList<string>();
            int div = 0; int divValue = 0;
            int mod = 0; int modValue = 0;
            foreach (string item in digits)
            {
                if (Int32.Parse(item) % 2 == 0)
                {
                    modValue = Int32.Parse(item);
                    mod++;
                }
                else
                {
                    divValue = Int32.Parse(item);
                    div++;
                }
            }
            return mod > div ? (digits.IndexOf(divValue.ToString()) + 1) : (digits.IndexOf(modValue.ToString()));
        }
        public static string PigIt(string str)
        {
            return string.Join(" ", str.Split(" ").ToList().Select(huy => huy.Substring(1) + huy[0] + "ay"));
        }
        public static string GetReadableTime(int seconds)
        {
            return $"{seconds / 60 / 60:00}:{seconds / 60 % 60:00}:{seconds % 60 % 60:00}";
        }
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            T previous = default;
            foreach (T current in iterable)
            {
                if (!current.Equals(previous))
                {
                    previous = current;
                    yield return current;
                }
            }
        }
    }
}
