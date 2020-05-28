// https://leetcode.com/explore/interview/card/amazon/79/sorting-and-searching/2993/

// Quick sort the array based on the first item then get intervals
public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.GetLength(0) <= 1) return intervals;
        QuickSort(0, intervals.GetLength(0)-1, intervals);
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int start = intervals[0][0];
        int end = intervals[0][1];
        for (int i = 1; i < intervals.GetLength(0); i++) {
            if (intervals[i][0] <= end) {
                end = Math.Max(end, intervals[i][1]);
            } else {
                dict.Add(start, end);
                start = intervals[i][0];
                end = intervals[i][1];
            }
        }
        dict.Add(start, end);
        int[][] result = new int[dict.Count][];
        int iter = 0;
        foreach(KeyValuePair<int, int> kvp in dict) {
            result[iter] = new int[2];
            result[iter][0] = kvp.Key;
            result[iter][1] = kvp.Value;
            iter++;
        }
        return result;
    }

    public void QuickSort(int l, int h, int[][] intervals) {
        if (l < h) {
            int j = Partition(l, h, intervals);
            QuickSort(l, j-1, intervals);
            QuickSort(j+1, h, intervals);
        }
    }

    public int Partition(int l, int h, int[][] intervals) {
        int pivot = intervals[h][0];
        int i = l - 1;

        for (int j = l; j < h; j++) {
            if (intervals[j][0] <= pivot) {
                i++;
                Swap(i, j, intervals);
            }
        }
        Swap(i+1, h, intervals);
        return i+1;
    }

    public void Swap(int i, int j, int[][] intervals) {
        int tempO = intervals[i][0];
        int tempT = intervals[i][1];
        intervals[i][0] = intervals[j][0];
        intervals[i][1] = intervals[j][1];
        intervals[j][0] = tempO;
        intervals[j][1] = tempT;
    }
}

// Input: [[1,3],[2,6],[8,14],[9,10], [5,9]]
// Input: [[1,3],[2,6],[8,10],[15,18]]
// Output: [[1,6],[8,10],[15,18]]
// Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].