// https://leetcode.com/problems/longest-palindromic-substring/

public class Solution {
    private int lo, hi, len;
    public string LongestPalindrome(string s) {
        // Empty or one char return s
        if (s.Length <= 1) return s;
        
        // Declare variables
        lo = 0;
        hi = 0;
        len = 0;
        
        for (int i = 0; i < s.Length - 1; i++) {
            // Check for odd numbered palindromes
            CheckPalindrome(s, i, i);
            // Check for even numbered palindromes
            CheckPalindrome(s, i, i+1);
        }
        return s.Substring(lo, len);
    }

    private void CheckPalindrome(string s, int i, int j) {
        while (i >= 0 && j < s.Length && s[i] == s[j]) {
            i--;
            j++;
        }
        i++;
        j--;
        if (s[j] == s[i]) {
            if (j - i + 1 > len) {
                lo = i;
                hi = j;
                len = j - i + 1;
            }
        }
    }
}

// Time Complexity: O(n^2)
// Space Complexity: O(1)




// Brute force
// Time Complexity: O(n^3)
// Space Complexity: O(1)
// public class Solution {
    // public string LongestPalindrome(string s) {
    //     // Empty or one char return s
    //     if (s.Length <= 1) return s;
        
    //     // Declare variables
    //     int left = 0;
    //     int right = s.Length - 1;
    //     string longestString = s[0].ToString();
        
    //     while (left < right) {
    //         while (right > left) {
    //             string sub = s.Substring(left, right-left+1);
    //             if (s[left] == s[right] && CheckPalindrome(sub)) {
    //                 longestString = sub.Length > longestString.Length ? sub : longestString;
    //             }
    //             right--;
    //         }
    //         right = s.Length - 1;
    //         left++;
    //     }
    //     return longestString;
    // }

    // private bool CheckPalindrome(string s) {
    //     if (s.Length == 0) return false;
    //     if (s.Length == 1) return true;
    //     int left = 0;
    //     int right = s.Length-1;
    //     while (left < s.Length/2) {
    //         if (s[left] != s[right]) {
    //             return false;
    //         }
    //         left++;
    //         right--;
    //     }
    //     return true;
    // }
// }