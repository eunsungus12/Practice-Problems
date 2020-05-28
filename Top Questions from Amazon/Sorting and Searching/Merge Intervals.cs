// https://leetcode.com/explore/interview/card/amazon/79/sorting-and-searching/2993/

public class Solution {
    public int[][] Merge(int[][] intervals) {
        HashSet<int> hs = new HashSet<int>();
        for(int i = 0; i < intervals.GetLength(0); i++) {
            if (hs.Contains(intervals[i][0])) {
                
            } else {
                for (int j = intervals[i][0]; j < intervals[i][1]; j++) {
                    hs.Add(j);
                }
            }
        }
    }
}