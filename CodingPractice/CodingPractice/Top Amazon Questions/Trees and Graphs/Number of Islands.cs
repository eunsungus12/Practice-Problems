using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Trees_and_Graphs
{
    class Number_of_Islands
    {
        // https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/894/

        // public static int NumIslands(char[][] grid)
        // {
        //     HashSet<Tuple<int, int>> allLand = new HashSet<Tuple<int, int>>();
        //     Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        //     Tuple<int, int> root = new Tuple<int, int>(0,0);

        //     for (int i = 0; i < grid.Length; i++) {
        //         for (int j = 0; j < grid[i].Length; j++) {
        //             if (grid[i][j] == '1') {
        //                 root = new Tuple<int, int>(i, j);
        //                 allLand.Add(root);
        //             }
        //         }
        //     }


        //     int result = 0;
        //     if (allLand.Count == 0) return result;
        //     queue.Enqueue(root);

        //     while (queue.Count > 0) {
        //         var land = queue.Dequeue();
        //         if (allLand.Contains(land)) allLand.Remove(land);

        //         int[] rows = new int[4] {-1, 0, 1, 0};
        //         int[] cols = new int[4] {0, 1, 0, -1};
        //         for (int i = 0; i < 4; i++) {
        //             int newX = land.Item1 + cols[i];
        //             int newY = land.Item2 + rows[i];
        //             Tuple<int, int> newLand = new Tuple<int, int>(newX, newY);
        //             if (allLand.Contains(newLand)) queue.Enqueue(newLand);
        //         }

        //         if (queue.Count == 0) {
        //             result++;
        //             if (allLand.Count > 0) {
        //                 foreach(Tuple<int, int> newLand in allLand) {
        //                     queue.Enqueue(newLand);
        //                     break;
        //                 }
        //             }
        //         }
        //     }
        //     return result;
        // }

        public int NumIslands(char[][] grid) {
            int result = 0;
            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    if (grid[i][j] == '1') {
                        result++;
                        Dfs(grid, i, j);
                    }
                }
            }
            return result;
        }

        private void Dfs(char[][] grid, int i, int j) {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length || grid[i][j] == '0') return;

            grid[i][j] = '0';
            
            int[] rows = new int[] {-1, 0, 1, 0};
            int[] cols = new int[] {0, 1, 0, -1};
            for (int d = 0; d < 4; d++) {
                int x = i + rows[d];
                int y = j + cols[d];
                Dfs(grid, x, y);
            }
        }
    }
}
