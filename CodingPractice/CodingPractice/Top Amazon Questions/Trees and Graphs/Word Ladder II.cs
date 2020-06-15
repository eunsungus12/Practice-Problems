using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Trees_and_Graphs
{
    class Word_Ladder_II
    {
        // https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/483/
        HashSet<string> toVisit;
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
            List<IList<string>> result = new List<IList<string>>();
            if (wordList.Count == 0) return result;
            toVisit = new HashSet<string>();
            foreach (string word in wordList) {
                toVisit.Add(word);
            }
            Bfs(result, beginWord, endWord, new List<string>());
            return result;
        }

        public void Bfs (List<IList<string>> result, string currWord, string endWord, List<string> myList) {
            myList.Add(currWord);
            if (currWord == endWord) {
                result.Add(myList);
                return;
            }
            List<string> toRemove = new List<string>();
            foreach (string word in toVisit) {
                if (ValidWord(currWord, word)) {
                    Bfs(result, word, endWord, new List<string>(myList));
                    toRemove.Add(word);
                }
            }
            foreach (string word in toRemove) {
                toVisit.Remove(word);
            }
        }

        private bool ValidWord(string start, string end) {
            int countDiff = 0;
            for (int i = 0; i < start.Length; i++) {
                if (start[i] != end[i]) countDiff++;
                if (countDiff > 1) return false;
            }
            return true;
        }
    }
}
