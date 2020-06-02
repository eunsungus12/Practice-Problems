// https://leetcode.com/problems/word-break/

public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        if (s.Length == 0 && wordDict.Count > 0) return false;
        
        HashSet<string> hs = new HashSet<string>(wordDict);
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(0);
        while(queue.Count > 0) {
            int start = queue.Dequeue();
            for (int j = start+1; j <= s.Length; j++) {
                if (hs.Contains(s.Substring(start, j-start))) {
                    if (j == s.Length) {
                        return true;
                    }
                    if (!visited.Contains(j)) {
                        visited.Add(j);
                        queue.Enqueue(j);
                    }
                }
            }
        }
        return false;
    }
}

