using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Dynamic_Programming
{
    class Letter_Combinations_of_a_Phone_Number
    {
        // https://leetcode.com/explore/interview/card/amazon/84/recursion/521/
        
        public static IList<string> LetterCombinations(string digits)
        {
            if (String.IsNullOrWhiteSpace(digits)) return new List<string>();
            List<string> map = new List<string>() {
                "0",
                "1",
                "abc",
                "def",
                "ghi",
                "jkl",
                "mno",
                "pqrs",
                "tuv",
                "wxyz"
            };
            List<string> result = new List<string>();
            LetterCombos(result, digits, "", map);

            return result;
        }

        private static void LetterCombos(List<string> result, string digits, string current, List<string> map)
        {
            if (string.IsNullOrWhiteSpace(digits))
            {
                result.Add(current);
                return;
            }
            int firstInt = Int32.Parse(digits[0].ToString());
            for (int i = 0; i < map[firstInt].Length; i++) {
                string fullString = current + map[firstInt][i].ToString();
                LetterCombos(result, digits.Substring(1, digits.Length-1), fullString, map);
            }
        }

        public static void Test()
        {
            Console.WriteLine("Testing Letter Combinations");
            string s = "23";
            var result = LetterCombinations(s);
            foreach(string res in result)
            {
                Console.WriteLine(res);
            }
            // "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
        }
    }
}
