// https://leetcode.com/explore/interview/card/amazon/79/sorting-and-searching/2992/

// ind = 0,1,2,3,4,5,6
//arr = [4,5,6,7,0,1,2];
//target = 0;

public class Solution {
    public int Search(int[] nums, int target) {
        int len = nums.Length;
        if (len == 0) return -1;
        if (len == 1) return nums[0] == target ? 0 : -1;
        int start = 0, end = len-1;
        while (start <= end) {
            int mid = start + (end - start) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] >= nums[start]) {
                if (target >= nums[start] & target < nums[mid]) {
                    end = mid - 1;
                } else {
                    start = mid + 1;
                }
            } else {
                if (target > nums[mid] & target <= nums[end]) {
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
        }
        return -1;
    }
}
