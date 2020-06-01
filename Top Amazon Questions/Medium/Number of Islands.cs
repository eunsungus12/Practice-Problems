// https://leetcode.com/problems/number-of-islands

public class Solution {
    public int NumIslands(char[][] grid) {
        // If empty island, return
        if (grid.Length == 0) return 0;

        // Declare Variables
        int counter = 0;
        Queue<Tuple<int, int>> theQueue = new Queue<Tuple<int, int>>();
        HashSet<Tuple<int, int>> set = new HashSet<Tuple<int, int>>();
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == '1') set.Add(new Tuple<int, int>(i, j));
            }
        }
        if (set.Count == 0) return 0;

        while (set.Count > 0) {
            Tuple<int, int> land = set.First();
            set.Remove(land);
            if (land != null) theQueue.Enqueue(land);
            while (theQueue.Count > 0) {
                land = theQueue.Dequeue();
                set.Remove(land);

                int[] dV = new int[] {-1, 0, 1, 0};
                int[] dH = new int[] {0, 1, 0, -1};
                for (int i = 0; i < 4; i++) {
                    int x = land.Item1 + dV[i];
                    int y = land.Item2 + dH[i];
                    Tuple<int, int> newLand = new Tuple<int, int>(x, y);
                    if (set.Contains(newLand)) {
                        theQueue.Enqueue(newLand);
                    }
                }
            }
            counter++;

            if (theQueue.Count == 0 & set.Count > 0) {
                theQueue.Enqueue(set.First());
            }
        }

        return counter;
    }
}
