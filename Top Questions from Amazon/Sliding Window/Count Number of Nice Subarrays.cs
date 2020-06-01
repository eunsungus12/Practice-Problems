//All sliding window questions:
// https://leetcode.com/problems/count-number-of-nice-subarrays/discuss/419378/JavaC%2B%2BPython-Sliding-Window-O(1)-Space
// https://leetcode.com/problems/count-number-of-nice-subarrays/

public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        // If more odd numbers wanted than numbers given, return 0
        if (nums.Length < k) return 0;

        // Declare variables
        int left = 0;
        int oddCounter = 0;
        int counter = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] % 2 == 1) oddCounter++;
            while (oddCounter > k) {
                left++;
                if (nums[left] % 2 == 1) oddCounter--;
                else counter++;
            }
            if (oddCounter == k) {
                counter++;
                while (oddCounter == k) {
                    left++;
                    if (nums[left] % 2 == 1) oddCounter--;
                    else counter++;
                }
            }
        }
        return counter;
    }
}
