using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Most_Common_Word
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2973/

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            if (paragraph.Length == 0) return "";
            HashSet<string> bad = new HashSet<string>(banned);
            paragraph = paragraph.Replace(",", " ").Replace(".", " ").Replace("!", " ").Replace("'", " ").Replace("?", " ").Replace(";", " ").ToLower().Trim();
            paragraph = Regex.Replace(paragraph, @"\s+", " ");
            string[] splitP = paragraph.Split(' ');
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string result = "";
            int maxCounter = 0;
            for (int i = 0; i < splitP.Length; i++)
            {
                if (bad.Contains(splitP[i])) continue;
                dict.TryAdd(splitP[i], 0);
                dict[splitP[i]]++;
                if (dict[splitP[i]] > maxCounter)
                {
                    result = splitP[i];
                    maxCounter = dict[splitP[i]];
                }
            }
            return result;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Most Common Word");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = new string[] { "hit" };
            Console.WriteLine("Expected: ball, Got: " + MostCommonWord(paragraph, banned));
            paragraph = "a, a, a, a, b,b,b,c, c";
            banned = new string[] { "a" };
            Console.WriteLine("Expected: b, Got: " + MostCommonWord(paragraph, banned));
        }
    }
}
