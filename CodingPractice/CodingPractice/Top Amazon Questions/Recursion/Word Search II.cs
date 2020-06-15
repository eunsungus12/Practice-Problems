using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Recursion
{
    class Word_Search_II
    {
        // https://leetcode.com/explore/interview/card/amazon/84/recursion/2990/

        public static IList<string> FindWords(char[][] board, string[] words)
        {
            TrieNode myTrie = new TrieNode();
            // Add word to Trie
            for(int i = 0; i < words.Length; i++) {
                if (string.IsNullOrWhiteSpace(words[i])) continue;
                TrieNode node = myTrie;
                string word = words[i];
                for (int j = 0; j < word.Length; j++) {
                    node.children.TryAdd(word[j], new TrieNode());
                    node = node.children[word[j]];
                }
                node.word = word;
            }

            List<string> result = new List<string>();
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    char c = board[i][j];
                    if (myTrie.children.ContainsKey(c)) {
                        Backtrack(board, myTrie, i, j, result);
                    }
                }
            }
            return result;
        }

        public static void Backtrack(char[][] board, TrieNode parentNode, int i, int j, List<string> result) {
            char letter = board[i][j];
            TrieNode childNode = parentNode.children[letter];

            if (childNode.word != null) {
                result.Add(childNode.word);
                childNode.word = null;
            }

            char temp = board[i][j];
            board[i][j] = ' ';

            var dV = new int[] {-1, 0, 1, 0};
            var dH = new int[] {0, 1, 0, -1};
            for (int d = 0; d < 4; d++) {
                var newX = i+dV[d];
                var newY = j+dH[d];
                if (newX < 0 || newY < 0 || newX >= board.Length || newY >= board[newX].Length || !childNode.children.ContainsKey(board[newX][newY])) continue;
                Backtrack(board, childNode, newX, newY, result);
            }
            
            board[i][j] = temp;
            if (childNode.children.Count == 0) {
                parentNode.children.Remove(letter);
            }
        }
        public static void Test()
        {
            Console.WriteLine("Testing Word Search II");
            char[][] board = new char[4][];
            board[0] = new char[4] { 'o', 'a', 'a', 'n' };
            board[1] = new char[4] { 'e', 't', 'a', 'e' };
            board[2] = new char[4] { 'i', 'h', 'k', 'r' };
            board[3] = new char[4] { 'i', 'f', 'l', 'v' };
            string[] words = new string[4] { "oath", "pea", "eat", "rain" };
            var result = FindWords(board, words);
            Console.WriteLine("Expected: oath, eat");
            foreach (string res in result)
            {
                Console.Write(res + "  ");
            }
            Console.WriteLine("");
            Console.WriteLine("Expected: dog, dogs");
            board[0] = new char[4] { 'o', 'a', 'a', 'n' };
            board[1] = new char[4] { 'e', 't', 'a', 's' };
            board[2] = new char[4] { 'i', 'd', 'o', 'g' };
            board[3] = new char[4] { 'i', 'f', 's', 's' };
            words = new string[4] { "oath", "dig", "dog", "dogs" };
            result = FindWords(board, words);
            foreach (string res in result)
            {
                Console.Write(res + "  ");
            }
            Console.WriteLine("");
        }

        public class TrieNode {
            public string word;
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        }
    }
}
