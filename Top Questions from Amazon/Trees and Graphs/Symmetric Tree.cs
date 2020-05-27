// https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/507/

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
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        return CheckSymmetry(root.left, root.right);
    }

    public bool CheckSymmetry(TreeNode left, TreeNode right) {
        if (left == null & right == null)
            return true;
        if (left == null & right != null | left != null & right == null)
            return false;
        if (left != null & right != null & left.val == right.val)
            return CheckSymmetry(left.right, right.left) & CheckSymmetry(left.left, right.right);
        return false;
    }
}