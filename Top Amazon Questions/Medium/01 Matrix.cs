// https://leetcode.com/problems/01-matrix/

// DP solution
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        // Iterate right each row then down
        // Set all distance to max if only going one direction -> down right
        for (int i = 0; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[i].Length; j++) {
                if (matrix[i][j] != 0) matrix[i][j] = GetMinDistance(matrix, i, j, true);
            }
        }
        
        // Iterate left each row the up
        // Update distances from bottom right to top left but update only if less than current distance
        for (int i = matrix.Length - 1; i >= 0; i--) {
            for (int j = matrix[i].Length-1; j >= 0; j--) {
                if (matrix[i][j] != 0) matrix[i][j] = Math.Min(matrix[i][j], GetMinDistance(matrix, i, j, false));
            }
        }

        return matrix;
    }

    // Direction to note which way we're iterating
    // True = down
    // False = up
    private int GetMinDistance(int[][] matrix, int x, int y, bool direction) {
        int min = Int32.MaxValue;

        if (direction) {
            if (x - 1 >= 0) min = Math.Min(matrix[x-1][y], min);
            if (y - 1 >= 0) min = Math.Min(matrix[x][y-1], min);
        } else {
            if (x + 1 < matrix.Length) min = Math.Min(matrix[x+1][y], min);
            if (y + 1 < matrix[x].Length) min = Math.Min(matrix[x][y+1], min);
        }
        return min == Int32.MaxValue ? min : min + 1;
    }
}
// Time Complexity: 

// BFS Solution
// Time Complexity: O(r * c)
// Space Complexity: O(r * c)
// public class Solution {
//     public int[][] UpdateMatrix(int[][] matrix) {
//         if (matrix.Length == 1 && matrix[0].Length == 1) return new int[][] {new int[] {0}};

//         // Declare variables
//         // hs to track visited coordinates, if not contains, means visited
//         HashSet<Tuple<int, int>> hs = new HashSet<Tuple<int, int>>();
//         int distance = 0;
//         Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

//         // Populate hs with non-0 coordinates
//         // Populate queue with 0 coordinates
//         for (int i = 0; i < matrix.Length; i++) {
//             for (int j = 0; j < matrix[i].Length; j++) {
//                 var coor = new Tuple<int, int>(i, j);
//                 if (matrix[i][j] == 0) queue.Enqueue(coor);
//                 else hs.Add(coor);
//             }
//         }

//         // BFS
//         Bfs(matrix, queue, hs, distance);
//         return matrix;
//     }

//         private void Bfs(int[][] matrix, Queue<Tuple<int, int>> queue, HashSet<Tuple<int, int>> hs, int distance) {
//         Queue<Tuple<int, int>> nextQueue = new Queue<Tuple<int, int>>();
//         while (queue.Count > 0) {
//             // Get first item in queue
//             var coor = queue.Dequeue();

//             // Update grid to distance if not zero
//             if (matrix[coor.Item1][coor.Item2] != 0) matrix[coor.Item1][coor.Item2] = distance;

//             // Loop through top, right, bottom, left
//             var dV = new int[] {-1, 0, 1, 0};
//             var dH = new int[] {0, 1, 0, -1};
//             for (int i = 0; i < 4; i++) {
//                 var newCoor = new Tuple<int, int>(coor.Item1 + dV[i], coor.Item2 + dH[i]);
//                 if (hs.Contains(newCoor)) {
//                     nextQueue.Enqueue(newCoor);
//                     // Remove from hashset to track visited
//                     hs.Remove(newCoor);
//                 }
//             }
//         }
//         distance++;
//         if (nextQueue.Count > 0) {
//             Bfs(matrix, nextQueue, hs, distance);
//         }
//     }
// }