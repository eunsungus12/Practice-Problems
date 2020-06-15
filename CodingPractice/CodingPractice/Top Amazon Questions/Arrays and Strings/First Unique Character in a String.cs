using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class First_Unique_Character_in_a_String
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/480/

        public static int FirstUniqChar(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return -1;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                dict.TryAdd(s[i], 0);
                dict[s[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1) return i;
            }
            return -1;
        }

        //public static int FirstUniqChar(string s)
        //{
        //    if (string.IsNullOrWhiteSpace(s)) return -1;
        //    int[] charArr = new int[26];
        //    for (int i = 0; i < s.Length; i++) charArr[s[i]-'a']++;
        //    for (int i = 0; i < s.Length; i++) {
        //        if (charArr[s[i]-'a'] == 1) return i;
        //    }
        //    return -1;
        //}

        public static void Test()
        {
            Console.WriteLine("Testing First Unique Char");
            string s = "leetcode";
            Console.WriteLine("Expected: 0, Got: " + FirstUniqChar(s).ToString());
            s = "loveleetocode";
            Console.WriteLine("Expected: 2, Got: " + FirstUniqChar(s).ToString());
            s = "aabbccddee";
            Console.WriteLine("Expected: -1, Got: " + FirstUniqChar(s).ToString());
            s = "dddccdbba";
            Console.WriteLine("Expected: 8, Got: " + FirstUniqChar(s).ToString());
        }
    }
}
