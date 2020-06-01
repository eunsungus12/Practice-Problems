// https://leetcode.com/problems/subtree-of-another-tree/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsSubtree(TreeNode s, TreeNode t) {
        return s != null & (IsEqual(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t));
    }

    private bool IsEqual(TreeNode s, TreeNode t) {
        if (s == null & t == null) return true;
        if (s == null || t == null) return false;

        return s.val == t.val & IsEqual(s.left, t.left) & IsEqual(s.right, t.right);
    }
}

// Time Complexity: O(m * n) where m is nodes in t and n is nodes in s
// space Complexity: O(n) where n is nodes in s, since recursively goes n nodes deep