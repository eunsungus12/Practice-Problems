using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class _3Sum
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2966/

        public static IList<IList<int>> ThreeSum(int[] nums)
		{
			if (nums.Length < 3) return new List<IList<int>>();
			Array.Sort(nums);
			List<IList<int>> result = new List<IList<int>>();
			for (int i = 0; i < nums.Length-2; i++)
			{
				// Skip duplicates
				if (i > 0 && nums[i - 1] == nums[i]) continue;
				int start = i + 1;
				int end = nums.Length - 1;
				while (start < end)
				{
					// If sum is greater than what's needed, decrement right
					if (nums[start] + nums[end] > -nums[i]) end--;
					// If sum is less than what's needed, increment left
					else if (nums[start] + nums[end] < -nums[i]) start++;
					// else store in results and increment left while there are dupes
					// and decrement right, while there are dupes
					else
					{
						result.Add(new int[3] { nums[i], nums[start], nums[end] });
						start++;
						end--;
						while (start < end && nums[start] == nums[start - 1]) start++;
						while (end > start && nums[end] == nums[end + 1]) end--;
					}
				}
			}
			return result; 
		}

		public static void Test()
		{
			Console.WriteLine("Testing ThreeSum");
			int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
			foreach(IList<int> list in ThreeSum(nums))
			{
				foreach(int val in list)
				{
					Console.Write(val.ToString() + " ");
				}
				Console.WriteLine("");
			}
		}

		// Someone elses solution
		public IList<IList<int>> ThreeSums(int[] nums)
		{
			// If invalid sized array, return empty list
			if (nums.Length < 3) return new List<IList<int>>();
			Array.Sort(nums);
			// Declare variables
			List<IList<int>> result = new List<IList<int>>();

			// stop i at 2 before length since j is i + 1 and k is length -1
			// so it can run i = Length - 3, j = Length - 2, k = Length -1
			for (int i = 0; i < nums.Length - 2; i++)
			{
				// Skip duplicates
				if (i > 0 && nums[i] == nums[i - 1]) continue;
				int j = i + 1;
				int k = nums.Length - 1;
				while (j < k)
				{
					// if two values greater than -nums[i] move left
					if (nums[j] + nums[k] > -nums[i]) k--;
					// else if less, move right
					else if (nums[j] + nums[k] < -nums[i]) j++;
					// else store in results
					else
					{
						List<int> tmp = new List<int>() { nums[i], nums[j], nums[k] };
						result.Add(tmp);
						// skip duplicates and increment/decrement j and k respectively
						while (j++ < nums.Length - 1 && nums[j] == nums[j - 1]) ;
						while (k-- > i && nums[k] == nums[k + 1]) ;
					}
				}
			}
			return result;
		}
	}
}
