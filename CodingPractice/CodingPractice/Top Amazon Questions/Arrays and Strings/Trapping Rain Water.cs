using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Trapping_Rain_Water
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2975/

        public static int Trap(int[] height)
        {
            if (height.Length == 2) return 0;
            int leftMax = Int32.MinValue, 
                rightMax = Int32.MinValue, 
                left = 0, 
                right = height.Length - 1,
                sum = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] > leftMax) leftMax = height[left];
                    else
                    {
                        sum += leftMax - height[left];
                        left++;
                    }
                } else
                {
                    if (height[right] > rightMax) rightMax = height[right];
                    else
                    {
                        sum += rightMax - height[right];
                        right--;
                    }
                }
            }
            return sum;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Trapping Rain Water");
            int[] input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine("Expected: 6, Got: " + Trap(input).ToString());
        }
    }
}
