// https://leetcode.com/problems/valid-parentheses/

public class Solution {
    public bool IsValid(string s) {
        if (s.Length == 0) return true;

        // Declare variables
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(' || s[i] == '{' || s[i] == '[') {
                stack.Push(s[i]);
            } else {
                if (stack.Count == 0) return false;
                if ((s[i] == ')' && stack.Peek() == '(') ||
                   (s[i] == ']' && stack.Peek() == '[') ||
                   (s[i] == '}' && stack.Peek() == '{')) {
                    stack.Pop();
                    continue;
                }
                return false;
            }
        }
        if (stack.Count == 0) return true;
        return false;
    }
}