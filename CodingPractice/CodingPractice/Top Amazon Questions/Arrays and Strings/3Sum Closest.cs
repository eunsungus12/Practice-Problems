using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class _3Sum_Closest
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2967/

        public static int ThreeSumClosest(int[] nums, int target)
        {
			Array.Sort(nums);
			int closest = nums[0] + nums[1] + nums[2];
			for (int i = 0; i < nums.Length - 2; i++)
			{
				if (i > 0 && nums[i] == nums[i - 1]) continue;
				int start = i + 1;
				int end = nums.Length - 1;
				while (start < end)
				{
					int currentSum = nums[i] + nums[start] + nums[end];
					if (currentSum == target) return currentSum;
					int currentDiff = Math.Abs(target - currentSum);
					if (currentDiff < Math.Abs(target - closest)) {
						closest = currentSum;
					}
					if (currentSum < target) start++;
					else if (currentSum > target) end--;
				}
			}
			return closest;
        }


		public static void Test()
		{
			Console.WriteLine("Testing ThreeSum");
			int[] nums = new int[] { -1, 2, 1, -4 };
			int target = 2;
			Console.WriteLine("Expected: 2, Got: " + ThreeSumClosest(nums, target).ToString());
		}
	}
}
