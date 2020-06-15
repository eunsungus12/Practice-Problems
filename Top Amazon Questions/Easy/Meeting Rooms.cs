// https://leetcode.com/problems/meeting-rooms/


public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        Array.Sort(intervals, (i1, i2) => i1[0].CompareTo(i2[0]));
        for (int i = 1; i < intervals.Length; i++) {
            if (intervals[i][0] < intervals[i-1][1]) return false;
        }
        return true;
    }
}

// Sort takes O(n*log(n))
// Space complexity: O(1)

// public class Solution {
//     public bool CanAttendMeetings(int[][] intervals) {
//         HashSet<int> hs = new HashSet<int>();
//         for (int i = 0; i < intervals.Length; i++) {
//             for (int j = intervals[i][0]; j < intervals[i][1]; j++) {
//                 if (hs.Contains(j)) return false;
//                 hs.Add(j);
//             }
//         }
//         return true;
//     }
// }

// Brute force: O(k) where k is every hour in every interval
// Space complexity: O(k) where k is every hour in every interval