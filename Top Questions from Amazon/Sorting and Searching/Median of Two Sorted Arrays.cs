// https://leetcode.com/explore/interview/card/amazon/79/sorting-and-searching/2991/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // O(log(n)) is too confusing for me
        // This runs in O(n)
        int totalCount = nums1.Count() + nums2.Count();
        int[] combinedArr = new int[totalCount];
        combinedArr = MergeArrays(nums1, nums2);
        if (totalCount % 2 == 1) return (double)combinedArr[totalCount/2];
        return (double)(combinedArr[totalCount/2 - 1] + combinedArr[totalCount/2]) / (double)2;

    }

    public int[] MergeArrays(int[] nums1, int[] nums2) {
        int[] result = new int[nums1.Count() + nums2.Count()];
        int resultIterator = 0;
        int oneIterator = 0;
        int twoIterator = 0;
        while (nums1.Count()-1 >= oneIterator & nums2.Count()-1 >= twoIterator) {
            if (nums1[oneIterator] < nums2[twoIterator]) {
                result[resultIterator] = nums1[oneIterator];
                oneIterator++;
            } else {
                result[resultIterator] = nums2[twoIterator];
                twoIterator++;
            }
            resultIterator++;
        }
        if (oneIterator < nums1.Count()) {
            while (oneIterator < nums1.Count()) {
                result[resultIterator] = nums1[oneIterator];
                oneIterator++;
                resultIterator++;
            }
        }
        if (twoIterator < nums2.Count()) {
            while (twoIterator < nums2.Count()) {
                result[resultIterator] = nums2[twoIterator];
                twoIterator++;
                resultIterator++;
            }
        }
        return result;
    }
}