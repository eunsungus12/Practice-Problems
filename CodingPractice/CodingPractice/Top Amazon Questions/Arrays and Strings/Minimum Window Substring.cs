using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Minimum_Window_Substring
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/902/

        // public static string MinWindow(string s, string t)
        // {
        //     if (s.Length == 0 || t.Length == 0 || t.Length > s.Length) return "";
        //     HashSet<char> hs = new HashSet<char>(t.ToCharArray());
        //     Dictionary<char, int> dict = new Dictionary<char, int>();
        //     string result = "";

        //     int end = 0;
        //     for (int i = 0; i < s.Length; i++)
        //     {
        //         if (hs.Contains(s[i]))
        //         {
        //             if (dict.ContainsKey(s[i]) && dict[s[i]] > i) continue;
        //             dict.TryAdd(s[i], i);
        //             end = Math.Max(i, end);
        //             while (end < s.Length && dict.Count < t.Length)
        //             {
        //                 end++;
        //                 if (hs.Contains(s[end]))
        //                 {
        //                     if (dict.ContainsKey(s[end]))
        //                     {
        //                         dict[s[end]] = end;
        //                     } else
        //                     {
        //                         dict.Add(s[end], end);
        //                     }
        //                 }
        //                 if (end == s.Length - 1) break;
        //             }
        //             if (dict.Count == t.Length) result = result.Length > end - i || result == "" ? s.Substring(i, end - i + 1) : result;
        //             if (dict[s[i]] == i) dict.Remove(s[i]);
        //         }
        //     }
        //     return result;
        // }

        public static string MinWindow(string s, string t) {
            if (t.Length > s.Length) return "";

            HashSet<char> hs = new HashSet<char>(t.ToCharArray());
            Dictionary<char, int> dict = new Dictionary<char, int>();

            // First count occurences of all letters of t in s
            for (int i = 0; i < s.Length; i++) {
                if (hs.Contains(s[i])) {
                    dict.TryAdd(s[i], 0);
                    dict[s[i]]++;
                }
            }

            // if s doesn't contain all of t's values, return ""
            if (dict.Count < hs.Count) return "";

            int start = 0, end = s.Length - 1;
            while (start < end) {
                if (dict.ContainsKey(s[start]) && dict[s[start]] <= 1) break;
                if (dict.ContainsKey(s[start])) dict[s[start]]--;
                start++;
            }
            while (end > start) {
                if (dict.ContainsKey(s[end]) && dict[s[end]] == 1) break;
                if (dict.ContainsKey(s[end])) dict[s[end]]--;
                end--;
            }

            return start >= end ? "" : s.Substring(start, end - start + 1);
        }

        public static void Test()
        {
            Console.WriteLine("Testing Mininum Window");
            string s = "ADOBECODEBANC";
            string t = "ABC";
            Console.WriteLine("Expected: BANC, Got: " + MinWindow(s, t));
            s = "aa";
            t = "aa";
            Console.WriteLine("Expected: aa, Got: " + MinWindow(s, t));
        }
    }
}
