// https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/514/

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
    public bool IsValidBST(TreeNode root) {
        if (root == null) return true;
        return ValidateNode(root.left, null, root.val) & ValidateNode(root.right, root.val, null);
    }

    public bool ValidateNode(TreeNode root, int? lowerBound, int? upperBound) {
        if (root == null) return true;
        if (root.val <= lowerBound || root.val >= upperBound) return false;
        return ValidateNode(root.left, lowerBound, root.val) & ValidateNode(root.right, root.val, upperBound);
    }
}