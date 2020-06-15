using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Implement_strStr__
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2968/

        public static int strStr(string haystack, string needle)
        {
            // What if needle's length is 0?
            if (needle.Length == 0) return 0;
            // What if length of needle is greater than haystack?
            if (haystack.Length < needle.Length) return -1;

            int result = -1;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Length - i < needle.Length) break;
                if (haystack[i] == needle[0] && haystack.Substring(i, needle.Length) == needle) return i;
            }
            return result;
        }

        public static void Test()
        {
            Console.WriteLine("Testing strStr");
            string s = "hello";
            string t = "ll";
            Console.WriteLine("Expected: 2, Got: " + strStr(s, t));
            s = "aaaaa";
            t = "bba";
            Console.WriteLine("Expected: -1, Got: " + strStr(s, t));
            s = "aaat";
            t = "at";
            Console.WriteLine("Expected: 2, Got: " + strStr(s, t));
        }
    }
}
