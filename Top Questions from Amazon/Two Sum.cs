// https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/508/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
		// Hash table to store numbers and their indices
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int[] result = new int[2];
        for (int i = 0; i < nums.Count(); i++) {
            int complement = target - nums[i];
			// Check if the complement (remainder) was pushed into the hash table, if so we have a solution
            if (dict.ContainsKey(complement)) {
                result[0] = dict[complement];
                result[1] = i;
                break;
            } else {
                if (!dict.ContainsKey(nums[i])) {
                    dict.Add(nums[i], i);
                }
            }
        }
        return result;
    }
}