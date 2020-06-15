using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Trees_and_Graphs
{
    class Word_Ladder
    {
        // https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/2982/
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            if (wordList.Count == 0) return 0;
            HashSet<string> toVisit = new HashSet<string>(wordList);
            if (toVisit.Contains(beginWord)) toVisit.Remove(beginWord);
            Queue<string> queue = new Queue<string>();
            int counter = 1;

            queue.Enqueue(beginWord);

            while (queue.Count > 0) {
                int qSize = queue.Count;
                for (int i = 0; i < qSize; i++) {
                    string currWord = queue.Dequeue();
                    List<string> toRemove = new List<string>();
                    foreach (string dictWord in toVisit) {
                        if (ValidWord(currWord, dictWord)) {
                            if (dictWord == endWord) return counter+1;
                            queue.Enqueue(dictWord);
                            toRemove.Add(dictWord);
                        }
                    }
                    foreach (string word in toRemove) {
                        toVisit.Remove(word);
                    }
                }

                counter++;
            }
            return 0;
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
