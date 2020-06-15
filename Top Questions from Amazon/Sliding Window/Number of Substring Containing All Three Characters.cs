// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/

public class Solution {
    public int NumberOfSubstrings(string s) {
        // Declare Variables
        int counter = 0;
        int windowStart = 0;
        int windowEnd = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();

        // Loop through string
        while (dict.Count < 3 & windowEnd < s.Length) {
            if (!dict.ContainsKey(s[windowEnd])) dict.Add(s[windowEnd], 1);
            else dict[s[windowEnd]]++;

            while (dict.Count == 3) {
                counter += s.Length - windowEnd;
                char leftChar = s[windowStart];
                dict[leftChar]--;
                if (dict[leftChar] == 0) dict.Remove(leftChar);
                windowStart++;
            }
            windowEnd++;
        }
        return counter;
    }
}


// Solution works but can be sped up by not looping through every string but
// skipping duplicate first letters and adjusting the count accordingly
// public class Solution {
//     public int NumberOfSubstrings(string s) {
//         // Declare Variables
//         int left = 0;
//         int right = 0;
//         int counter = 0;
//         Dictionary<char, int> dict = new Dictionary<char, int>();
        
//         while (left < s.Length-2) {
//             while (dict.Count < 3 & right < s.Length) {
//                 dict[s[right]] = right;
//                 right++;
//             }
//             if (dict.Count == 3) {
//                 counter += s.Length - right + 1;
//                 if (dict[s[left]] == left) {
//                     dict.Remove(s[left]);
//                 }
//                 left++;
//             } else {
//                 return counter;
//             }
            
//         }
//         return counter;
//     }
// }

// Brute force -> will time out
// public class Solution {
//     public int NumberOfSubstrings(string s) {
//         // Declare variables
//         int left = 0;
//         HashSet<string> hs = new HashSet<string>();
//         List<string> result = new List<string>();
        
//         // Create hashset of unique letters
//         hs.Add("a");
//         hs.Add("b");
//         hs.Add("c");
        
//         // Loop through left to right of the string
//         while (left < s.Length & (s.Length - left) >= hs.Count) {
//             int right = s.Length;
//             // start with largest possible word and decrement
//             while (right > left) {
//                 if (ContainsAll(hs, s.Substring(left, right-left))) {
//                     result.Add(s.Substring(left,right-left));
//                 } else {
//                     right = 0;
//                 }
//                 right--;
//             }
//             left++;
//         }
        
//         return result.Count;
//     }
    
//     private bool ContainsAll(HashSet<string> letters, string word) {
//         foreach(string l in letters) {
//             if (!word.Contains(l)) return false;
//         }
//         return true;
//     }
// }