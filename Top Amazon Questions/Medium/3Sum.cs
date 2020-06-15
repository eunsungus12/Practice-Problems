// https://leetcode.com/problems/3sum/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // If invalid sized array, return empty list
        if (nums.Length < 3) return new List<IList<int>>();
        Array.Sort(nums);
        // Declare variables
        List<IList<int>> result = new List<IList<int>>();

        // stop i at 2 before length since j is i + 1 and k is length -1
        // so it can run i = Length - 3, j = Length - 2, k = Length -1
        for (int i = 0; i < nums.Length - 2; i++) {
            // Skip duplicates
            if (i > 0 && nums[i] == nums[i-1]) continue;
            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k) {
                // if two values greater than -nums[i] move left
                if (nums[j] + nums[k] > -nums[i]) k--;
                // else if less, move right
                else if (nums[j] + nums[k] < -nums[i]) j++;
                // else store in results
                else {
                    List<int> tmp = new List<int>() {nums[i], nums[j], nums[k]};
                    result.Add(tmp);
                    // skip duplicates and increment/decrement j and k respectively
                    while (j++ < nums.Length-1 && nums[j] == nums[j-1]);
                    while (k-- > i && nums[k] == nums[k+1]);
                }
            }
        }
        return result;
    }
}
