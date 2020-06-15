// https://leetcode.com/problems/longest-increasing-subsequence/

public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length == 0) return 0;

        int[] maxes = new int[nums.Length];
        maxes[0] = 1;
        for (int i = 0; i < nums.Length; i++) {
            int maxval = 0;
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j]) maxval = Math.Max(maxval, maxes[j]);
            }
            maxes[i] = maxval + 1;
            00
        }
    }
}