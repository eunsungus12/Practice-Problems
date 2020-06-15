using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Recursion
{
    class Generate_Parentheses
    {
        // https://leetcode.com/explore/interview/card/amazon/84/recursion/2988/

        public static IList<string> GenerateParenthesis(int n) {
            List<string> result = new List<string>();
            Backtrack(result, "", 0, 0, n);
            return result;
        }

        public static void Backtrack(List<string> result, string currentStr, int leftParCount, int rightParCount, int n) {
            if (currentStr.Length == n*2) {
                result.Add(currentStr);
                return;
            }
            if (leftParCount < n) Backtrack(result, currentStr + "(", leftParCount + 1, rightParCount, n);
            if (rightParCount < leftParCount) Backtrack(result, currentStr + ")", leftParCount, rightParCount+1, n);
        }
        public static void Test()
        {
            Console.WriteLine("Testing Generate Parentheses");
            int n = 3;
            IList<string> result = GenerateParenthesis(n);
            foreach (string res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}
