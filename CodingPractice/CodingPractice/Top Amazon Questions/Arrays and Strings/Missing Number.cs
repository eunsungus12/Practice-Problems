using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Missing_Number
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2971/
        public static int MissingNumber(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>(nums);
            for (int i = 0; i <= nums.Length; i++)
            {
                if (!hs.Contains(i)) return i;
            }
            return 0;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Missing Number");
            int[] nums = new int[] { 3, 0, 1 };
            Console.WriteLine("Expected: 2, Got: " + MissingNumber(nums).ToString());
            nums = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            Console.WriteLine("Expected: 8, Got: " + MissingNumber(nums).ToString());
        }
    }
}
