using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Assert.AreEqual("YES", Kata.Tickets(new int[] { 25, 25, 50, 50 }));
            Assert.AreEqual("NO", Kata.Tickets(new int[] { 25, 100 }));
            Assert.AreEqual("NO", Kata.Tickets(new int[] { 25, 25, 50, 50, 100 }));

            Console.WriteLine("Well done!");
            Console.ReadKey();
        }
        
    }
    class Kata
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
            if (currentIndex == 0) result = 0;
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
            if (currentIndex == arr.Length) result = 0;
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

            string pattern = @"[-_]";
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
                else if (human / 50 == 1)
                {
                    if (bill25-- < 0)
                    {
                        result = "NO";
                        break;
                    }
                    bill50++;
                }
                else if (human / 100 == 1)
                {
                    if(bill50-- < 0 || bill25-- < 0)
                    {
                        if(bill25 - 3 < 0)
                        {
                            result = "NO";
                            break;
                        }
                        else
                        {
                            bill25 -= 3;
                        }
                    }
                    else
                    {
                        bill50--;
                        bill25--;
                    }
                    bill100++;
                }
                else
                {
                    result = "NO";
                    break;
                }
            }

            return result;
        }
    }
}
