using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CodingPractice.Sliding_Window
{
    class Get_Equal_Substrings_Within_Budget
    {
        // https://leetcode.com/problems/get-equal-substrings-within-budget/

        public static int EqualSubstring(string s, string t, int maxCost)
        {
            return 0;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Total Fruit");
            string s = "abcd";
            string t = "bcdf";
            int maxCost = 3;
            Console.WriteLine("Expected: 3, Got: " + EqualSubstring(s, t, maxCost).ToString());
            s = "abcd";
            t = "cdef";
            maxCost = 3;
            Console.WriteLine("Expected: 1, Got: " + EqualSubstring(s, t, maxCost).ToString());
            s = "abcd";
            t = "acde";
            maxCost = 0;
            Console.WriteLine("Expected: 1, Got: " + EqualSubstring(s, t, maxCost).ToString());
        }
    }
}
