using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Sliding_Window
{
    // https://leetcode.com/problems/replace-the-substring-for-balanced-string/
    class Replace_the_Substring_for_Balanced_String
    {
        public static int BalancedString(string s)
        {
            if (s.Length == 0) return 0;

            int charLimit = s.Length / 4;
            Dictionary<char, int> dict = new Dictionary<char, int>() { { 'Q', 0 }, { 'W', 0 }, { 'E', 0 }, { 'R', 0 } };
            Dictionary<char, int> wrongDict = new Dictionary<char, int>();
            int totalSwitches = Int32.MaxValue;
            foreach (char c in s) dict[c]++;
            CheckBalance(dict, charLimit, wrongDict);
            if (wrongDict.Count == 0) return 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!wrongDict.ContainsKey(s[i])) continue;

                int end = i;
                while (wrongDict.Count > 0 && end < s.Length-1)
                {
                    end++;
                    if (wrongDict.ContainsKey(s[end]))
                    {
                        wrongDict[s[end]]--;
                        if (wrongDict[s[end]] == 0) wrongDict.Remove(s[end]);
                    }
                }
                CheckBalance(dict, charLimit, wrongDict);
                totalSwitches = Math.Min(totalSwitches, end - i);
            }
            return totalSwitches;
        }

        private static void CheckBalance(Dictionary<char, int> dict, int max, Dictionary<char, int> wrongDict)
        {
            foreach (KeyValuePair<char, int> kvp in dict)
            {
                if (kvp.Value > max)
                {
                    if (wrongDict.ContainsKey(kvp.Key)) wrongDict.Remove(kvp.Key);
                    wrongDict.Add(kvp.Key, kvp.Value - max);
                }
            }
        }

        public static void Test()
        {
            Console.WriteLine("Testing Balanced String");
            string input = "QWER";
            //Console.WriteLine("Expected: 0, Got: " + BalancedString(input).ToString());
            input = "QQWE";
            //Console.WriteLine("Expected: 1, Got: " + BalancedString(input).ToString());
            input = "QQQW";
            //Console.WriteLine("Expected: 2, Got: " + BalancedString(input).ToString());
            input = "QQQQ";
            Console.WriteLine("Expected: 3, Got: " + BalancedString(input).ToString());
            input = "QQWWEERR";
            Console.WriteLine("Expected: 0, Got: " + BalancedString(input).ToString());
            input = "QWWWEWRR";
            Console.WriteLine("Expected: 2, Got: " + BalancedString(input).ToString());
            input = "QQEQEQRQ";
            Console.WriteLine("Expected: 4, Got: " + BalancedString(input).ToString());
            input = "WWEQERQWQWWRWWERQWEQ"; // 20
            Console.WriteLine("Expected: 4, Got: " + BalancedString(input).ToString());
        }
    }
}
