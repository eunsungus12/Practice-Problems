using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    // https://leetcode.com/problems/max-consecutive-ones-iii
    public class MaxConsecutiveOnesIII{
        public static int LongestOnes(int[] A, int K)
        {
            if (A.Length <= 1) return A[0];
            int i = 0, j;
            for (j = 0; j < A.Length; j++)
            {
                if (A[j] == 0) K--;
                if (K < 0)
                {
                    if (A[i] == 0) K++;
                    i++;
                }
            }
            return j - i;
        }
        public static void Test()
        {
            Console.WriteLine("Testing Max Consecutive Ones III");
            int[] input = new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            int K = 2;

            Console.WriteLine(LongestOnes(input, K).ToString());
            Console.WriteLine(LongestOnes(new int[] { 1 }, K).ToString());
            Console.WriteLine(LongestOnes(new int[] { 0 }, K).ToString());

            input = new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 };
            Console.WriteLine(LongestOnes(input, 3).ToString());
        }

    }
}
