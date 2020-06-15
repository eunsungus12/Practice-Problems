using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions
{
	class Container_With_Most_Water
	{
		// https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2963/

		public static int MaxArea(int[] height)
		{
			if (height.Length == 2) return Math.Min(height[0], height[1]);
			int left = 0, right = height.Length - 1, max = Int32.MinValue;
			while (left < right)
			{
				max = Math.Max(max, (Math.Min(height[left], height[right]) * (right - left)));
				if (height[left] >= height[right]) right--;
				else left++;
			}
			return max;
		}

		// Time Complexity: O(n^2)
		//public static int MaxArea(int[] height)
		//{
		//	if (height.Length == 2) return Math.Min(height[0], height[1]);

		//	int max = Int32.MinValue;
		//	for (int i = 0; i < height.Length; i++)
		//	{
		//		for (int j = i; j < height.Length; j++)
		//		{
		//			max = Math.Max(max, (Math.Min(height[i], height[j]) * (j - i)));
		//		}
		//	}
		//	return max;
		//}
		public static void Test()
		{
			Console.WriteLine("Testing Word Break");
			int[] s = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
			Console.WriteLine("Expected: 49, Got: " + MaxArea(s).ToString());
			s = new int[] { 1, 1, 1, 1, 1 };
			Console.WriteLine("Expected: 4, Got: " + MaxArea(s).ToString());
			s = new int[] { 10, 8, 6, 2, 5, 4, 9 };
			Console.WriteLine("Expected: 54, Got: " + MaxArea(s).ToString());
			s = new int[] { 20, 10, 8, 3, 7 };
			Console.WriteLine("Expected: 28, Got: " + MaxArea(s).ToString());
		}
	}
}
