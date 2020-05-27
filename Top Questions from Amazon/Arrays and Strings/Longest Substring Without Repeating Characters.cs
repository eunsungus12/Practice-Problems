//https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2961/

public class Solution {
	public int LengthOfLongestSubstring(string s) {
		int start = 0;
		int longestLength = 0;
		Dictionary<char, int> dict = new Dictionary<char, int>();
		for (int i = 0; i < s.Length; i++) {
			if (dict.ContainsKey(s[i])) {
				if (dict[s[i]] >= start) start = dict[s[i]] + 1;
				longestLength = longestLength < i - start + 1 ? i - start + 1 : longestLength;
				dict[s[i]] = i;
			} else {
				dict.Add(s[i], i);
				if (longestLength < i - start + 1) longestLength++;
			}
		}
		return longestLength;
	}
}
