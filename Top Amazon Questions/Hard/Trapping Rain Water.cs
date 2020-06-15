// https://leetcode.com/problems/trapping-rain-water/

public class Solution {
    public int Trap(int[] height) {
        if (height.Length <= 2) return 0;
        int collected = 0;
        int left = 0;
        int leftMax = Int32.MinValue;
        int right = height.Length;
        int rightMax = Int32.MinValue;

        while (left < right) {
            if (height[left] < height[right]) {
                if (leftMax <= height[left]) leftMax = height[left];
                else collected += leftMax - height[left];
                left++;
            } else {
                if (rightMax <= height[right]) rightMax = height[right];
                else collected += rightMax - height[right];
                right--;
            }
            
        }
        return collected;
    }
}