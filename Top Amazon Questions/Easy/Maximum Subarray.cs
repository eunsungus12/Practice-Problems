// https://leetcode.com/problems/maximum-subarray/

public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums.Length == 0) return 0;
        
        // Declare Varibles
        int maxSum = nums[0];
        int runningSum = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            runningSum = Math.Max(nums[i], (runningSum + nums[i]));
            maxSum = Math.Max(maxSum, runningSum);
        }
        
        return maxSum;
    }
}

// Time Complexity: O(n)
// Space Complexity: O(1)