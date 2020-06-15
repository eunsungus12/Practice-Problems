// https://leetcode.com/problems/rotting-oranges/

public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid.Length == 0) return 0;

        // Declare variables
        HashSet<Tuple<int, int>> hs = new HashSet<Tuple<int, int>>();
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        int days = 0;
        // Populate Hashset with fresh oranges
        // Populate Queue with rotten oranges
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 1) hs.Add(new Tuple<int, int>(i, j));
                if (grid[i][j] == 2) queue.Enqueue(new Tuple<int, int>(i, j));
            }
        }
        // Iterate through queue and remove from hashset any fresh oranges
        while (queue.Count > 0) {
            Queue<Tuple<int, int>> nextQueue = new Queue<Tuple<int, int>>();
            while (queue.Count > 0) {
                nextQueue.Enqueue(queue.Dequeue());
            }
            while (nextQueue.Count > 0) {
                Tuple<int, int> rottenO = nextQueue.Dequeue();
                if (hs.Contains(rottenO)) hs.Remove(rottenO);
                int[] dV = new int[] {-1, 0, 1, 0};
                int[] dH = new int[] {0, 1, 0, -1};
                for (int i = 0; i < 4; i++) {
                    int x = rottenO.Item1 + dV[i];
                    int y = rottenO.Item2 + dH[i];
                    if (x >= 0 && y >= 0 && x < grid.Length && y < grid[x].Length) {
                        Tuple<int, int> nextLand = new Tuple<int, int>(x, y);
                        if (hs.Contains(nextLand)) queue.Enqueue(nextLand);
                    }
                }
            }
            if (hs.Count > 0) {
                days++;
            }
        }
        if (hs.Count > 0) return -1;
        return days;
    }
}