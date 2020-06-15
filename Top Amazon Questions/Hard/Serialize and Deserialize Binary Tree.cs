// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) return "null";
        return root.val + "," + serialize(root.left) + "," + serialize(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "null") return null;

        List<TreeNode> list = new List<TreeNode>();

        string[] values = data.Split(',');
        TreeNode root = new TreeNode(Convert.ToInt32(values[0]));
        list.Add(root);

        bool left = true;
        for (int i = 1; i < values.Length; i++) {
           if (values[i] == "null") {

           } else {
               
           }
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));