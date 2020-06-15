using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    class Combination_Sum_II
    {
        // https://leetcode.com/problems/combination-sum-ii/

        private HashSet<string> dupes;
        public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
            List<IList<int>> result = new List<IList<int>>();
            if (candidates == null || candidates.Length == 0) return result;
            Array.Sort(candidates);
            dupes = new HashSet<string>();
            // for (int i = 0; i < candidates.Length; i++) { // O(n)
            //     if ((i > 0 && candidates[i] == candidates[i-1]) || candidates[i] > target) continue;
            Combine(result, candidates, 0, target, new List<int>());
            // }
            return result;
        }

        public void Combine(List<IList<int>> result, int[] candidates, int currIndex, int currRemainder, List<int> currList) {
            if (currRemainder == 0) {
                string check = string.Join("", currList);
                if (!dupes.Contains(check)) {
                    dupes.Add(check);
                    result.Add(currList);
                }
                return;
            }

            for (int i = currIndex; i < candidates.Length; i++) { // O(n)
                if (candidates[i] > currRemainder) continue;
                if (i > currIndex + 1 && candidates[i] == candidates[i-1]) continue;
                List<int> newList = new List<int>(currList);
                newList.Add(candidates[i]);
                Combine(result, candidates, i, currRemainder - candidates[i], newList);
            }
        }
    }
}
