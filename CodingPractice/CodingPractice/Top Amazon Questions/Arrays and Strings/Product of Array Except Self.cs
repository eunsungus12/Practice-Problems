using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Product_of_Array_Except_Self
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/499/

        public static int[] ProductExceptSelf(int[] nums) {
            int[] result = new int[nums.Length];
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++) {
                if (i == 0) left[i] = 1;
                else {
                    left[i] = left[i-1] * nums[i-1];
                }
            }
            for (int i = nums.Length-1; i >= 0; i--) {
                if (i == nums.Length-1) right[i] = 1;
                else {
                    right[i] = right[i+1] * nums[i+1];
                }
            }
            for (int i = 0; i < nums.Length; i++) {
                result[i] = left[i] * right[i];
            }
            return result;
        }

        public static void Test() {
            Console.WriteLine("Testing Product of Array Except Self");
            int[] nums = new int[5] {4,5,1,8,2};
            var result = ProductExceptSelf(nums);
            foreach(int res in result) {
                Console.Write(res.ToString() + " ");
            }
        }
    }
}
