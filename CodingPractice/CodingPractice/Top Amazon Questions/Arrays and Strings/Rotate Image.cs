using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Arrays_and_Strings
{
    class Rotate_Image
    {
        // https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2969/

        private static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                }
            }
        }

        private static void Flip(int[][] matrix)
        {
            int n = matrix.Length;

        }

        public static void Test()
        {
            Console.WriteLine("Testing Rotate Matrix");
            int[][] m = new int[3][] { new int[3] { 1,2,3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } };
            Rotate(m);
        }
    }
}
