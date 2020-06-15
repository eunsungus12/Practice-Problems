using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Group_Anagrams
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2970/

        private static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs.Length == 0) return new List<IList<string>>();
            if (strs.Length == 1) return new List<IList<string>>() { new List<string>() { strs[0] } };
            
            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
            foreach(string str in strs) // O(n)
            {
                var charArr = str.ToCharArray(); // O(K) where k is length of word
                Array.Sort(charArr);                    // O(k Log(k)
                string sortedStr = new string(charArr);
                dict.TryAdd(sortedStr, new List<string>()); // Tries to add to dict, if exists, then false
                dict[sortedStr].Add(str);
            }
            return dict.Values.ToList(); // O(n * k * Log(k))
        }

        public static void Test()
        {
            Console.WriteLine("Testing Group Anagrams");
            string[] input = new string[6] { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> result = GroupAnagrams(input);
            foreach(IList<string> list in result)
            {
                foreach(string str in list)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
