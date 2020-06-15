
public class Solution {
    public int LongestSubstringKDistinct(string[] strArr, int k) {
        // Declare Variables
        int maxSubstring = 0;
        int windowStart = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();

        // Loop through
        for (int windowEnd = 0; windowEnd < strArr.Length; windowEnd++) {
            if (dict.ContainsKey(strArr[windowEnd])) dict[strArr[windowEnd]]++;
            else dict.Add(strArr[windowEnd], 1);

            while (dict.Count > k) {
                char leftChar = strArr[windowStart];
                dict[leftChar]--;
                if (dict[leftChar] == 0) dict.Remove(leftChar);
                windowStart++;
            }
            maxSubstring = Math.Max(maxSubstring, windowEnd - windowStart+1);
        }

        return maxSubstring;

    }
}