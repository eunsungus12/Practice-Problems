// Graph problems:
// https://leetcode.com/discuss/general-discussion/655708/graph-problems-for-beginners-practice-problems-and-sample-solutions
// https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/506/

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) return new List<IList<int>>();
        // Declare variables
        IList<IList<int>> result = new List<IList<int>>();
        Queue<TreeNode> que = new Queue<TreeNode>();

        // Add root to queue
        que.Enqueue(root);

        while (que.Count > 0) {
            Queue<TreeNode> nextQue = new Queue<TreeNode>(que);
            que.Clear();
            List<int> level = new List<int>();
            while (nextQue.Count > 0) {
                TreeNode node = nextQue.Dequeue();
                level.Add(node.val);
                if (node.left != null) que.Enqueue(node.left);
                if (node.right != null) que.Enqueue(node.right);
            }
            result.Add(level);
        }
        return result;
    }
}