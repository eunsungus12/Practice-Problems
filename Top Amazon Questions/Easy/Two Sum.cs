// https://leetcode.com/problems/two-sum/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums.Length <= 1) return new int[] {};

        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            if (dict.ContainsKey(target - nums[i])) {
                return new int[] {dict[target - nums[i]], i};
            }
            if (!dict.ContainsKey(nums[i])) dict.Add(nums[i], i);
        }
        return new int[] {};
    }
}