// https://leetcode.com/problems/partition-labels/

public class Solution {
    public IList<int> PartitionLabels(string S) {
        // Base case
        if (S.Length == 1) return new List<int>() {1};
        
        Dictionary<char, int> lastOcc = new Dictionary<char, int>();
        for (int i = 0; i <  S.Length; i++) {
            if (lastOcc.ContainsKey(S[i])) lastOcc[S[i]] = i;
            else lastOcc.Add(S[i], i);
        }
        
        int anchor = 0;
        int right = 0;
        IList<int> result = new List<int>();
        for (int i = 0; i < S.Length; i++) {
            right = Math.Max(right, lastOcc[S[i]]);
            if (i == right) {
                result.Add(i - anchor + 1);
                anchor = i + 1;
            }
        }
        return result;
    }
}

// Time Complexity: O(n)
// Space Complexity: O(1)