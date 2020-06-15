using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Valid_Parentheses
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2972/

        public static bool IsValid(string s)
        {
            if (s.Length == 0) return true;
            if (s.Length % 2 == 1) return false;
            string curr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ')' || s[i] == ']' || s[i] == '}')
                {
                    if (curr.Length == 0) return false;
                    if (s[i] == ')' && curr[curr.Length - 1] != '(') return false;
                    if (s[i] == ']' && curr[curr.Length - 1] != '[') return false;
                    if (s[i] == '}' && curr[curr.Length - 1] != '{') return false;
                    curr = curr.Length <= 1 ? "" : curr.Substring(0, curr.Length - 1);
                } else curr += s[i];
            }
            return curr.Length == 0;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Valid Parentheses");
            string s = "()";
            Console.WriteLine("Expected: true, Got: " + IsValid(s).ToString());
            s = "()[]{}";
            Console.WriteLine("Expected: true, Got: " + IsValid(s).ToString());
            s = "(]";
            Console.WriteLine("Expected: false, Got: " + IsValid(s).ToString());
        }
    }
}
