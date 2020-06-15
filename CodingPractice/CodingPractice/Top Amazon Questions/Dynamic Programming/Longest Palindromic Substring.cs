using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Dynamic_Programming
{
    class Longest_Palindromic_Substring
    {
        // https://leetcode.com/explore/interview/card/amazon/80/dynamic-programming/489/
        public static string LongestPalindrome(string s)
        {
            if (s.Length <= 1) return s;
            string longest = "";
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int len;
                int lenOdd = Palindrome(s, i, i);
                int lenEven = Palindrome(s, i, i + 1);
                len = Math.Max(lenOdd, lenEven);
                if (longest.Length < len)
                {
                    longest = s.Substring(i - (len - 1) / 2, len);
                }
            }
            return longest;
        }

        private static int Palindrome(string s, int start, int end)
        {
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }
            return end - start - 1;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Longest Palindromic Substring");
            string s = "babad";
            Console.WriteLine("Expected: bab or aba, Got: " + LongestPalindrome(s));
            s = "cbbd";
            Console.WriteLine("Expected: bb, Got: " + LongestPalindrome(s));
            s = "dbbbae";
            Console.WriteLine("Expected: bbb, Got: " + LongestPalindrome(s));
            s = "ac";
            Console.WriteLine("Expected: a or c, Got: " + LongestPalindrome(s));
        }
    }
}
