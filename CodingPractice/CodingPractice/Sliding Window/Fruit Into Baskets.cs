using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingPractice.Sliding_Window
{
    // https://leetcode.com/problems/fruit-into-baskets/
    class Fruit_Into_Baskets
    {
        public class Node
        {
            int val;
            int index;
            public Node(int val, int index)
            {
                this.val = val;
                this.index = index;
            }
        }

        public static int TotalFruit(int[] tree)
        {
            if (tree.Length == 0) return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int start = 0;
            int max = 0;

            for (int i = 0; i < tree.Length; i++)
            {
                if (dict.ContainsKey(tree[i])) dict[tree[i]] = i;
                else dict.Add(tree[i], i);

                if (dict.Count > 2)
                {
                    if (dict[tree[start]] == start)
                    {
                        dict.Remove(tree[start]);
                    }
                    start++;
                }

                if (dict.Count < 3) max = Math.Max(max, i - start + 1);
            }

            // Length of longest suarray containing at most 2 distinct #'s
            return max;
        }
        //public static int TotalFruit(int[] tree)
        //{
        //    if (tree.Length == 0) return 0;

        //    Dictionary<int, int> dict = new Dictionary<int, int>();
        //    int[] tracker = new int[2];
        //    int start = 0;
        //    int max = 0;

        //    for (int i = 0; i < tree.Length; i++)
        //    {
        //        if (dict.ContainsKey(tree[i]))
        //        {
        //            dict[tree[i]] = i;
        //        } else
        //        {
        //            if (dict.Count <= 1)
        //            {
        //                tracker[dict.Count] = tree[i];
        //                dict.Add(tree[i], i);
        //            } else
        //            {
        //                int t = dict[tracker[0]] < dict[tracker[1]] ? 0 : 1;
        //                start = dict[tracker[t]] + 1;
        //                dict.Remove(tracker[t]);
        //                tracker[t] = tree[i];
        //                dict.Add(tracker[t], i);
        //            }
        //        }
        //        max = Math.Max(max, i - start + 1);
        //    }

        //    // Length of longest suarray containing at most 2 distinct #'s
        //    return max;
        //}

        public static void Test()
        {
            Console.WriteLine("Testing Total Fruit");
            int[] input = new int[] { 1, 2, 1 };
            Console.WriteLine("Expected: 3, Got: " + TotalFruit(input).ToString());
            input = new int[] { 0, 1, 2, 2 };
            Console.WriteLine("Expected: 3, Got: " + TotalFruit(input).ToString());
            input = new int[] { 1, 2, 3, 2, 2 };
            Console.WriteLine("Expected: 4, Got: " + TotalFruit(input).ToString());
            input = new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 };
            Console.WriteLine("Expected: 5, Got: " + TotalFruit(input).ToString());
        }

    }
}
