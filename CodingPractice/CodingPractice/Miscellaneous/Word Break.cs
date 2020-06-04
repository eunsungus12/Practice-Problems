using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class Word_Break
    {
        // https://leetcode.com/problems/word-break/

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            if (s.Length == 0) return true;
            HashSet<string> hs = new HashSet<string>(wordDict);
            bool[] wordCheck = new bool[s.Length+1];
            wordCheck[0] = true;
            for (int i = 1; i < s.Length+1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (wordCheck[j] && hs.Contains(s.Substring(j, i - j)))
                    {
                        wordCheck[i] = true;
                        break;
                    }
                }
            }
            return wordCheck[s.Length];
        }

        public static void Test()
        {
            Console.WriteLine("Testing Word Break");
            string s = "leetcode";
            string[] wordDict = new string[] { "leet", "code" };
            Console.WriteLine("Expected: true, Got: " + WordBreak(s, wordDict).ToString());
            s = "applepenapple";
            wordDict = new string[] { "apple", "pen" };
            Console.WriteLine("Expected: true, Got: " + WordBreak(s, wordDict).ToString());
            s = "catsandog";
            wordDict = new string[] { "cats", "dog", "sand", "and", "cat" };
            Console.WriteLine("Expected: false, Got: " + WordBreak(s, wordDict).ToString());
            s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
            wordDict = new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };
            //Console.WriteLine("Expected: false, Got: " + WordBreak(s, wordDict).ToString());
            bool[] f = new bool[4];

        }
    }
}
