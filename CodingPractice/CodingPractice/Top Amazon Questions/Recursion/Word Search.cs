using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Recursion
{
    class Word_Search
    {
        // https://leetcode.com/explore/interview/card/amazon/84/recursion/2989/

        public static bool Exist(char[][] board, string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return true;
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (word[0] == board[i][j] && Backtrack(board, word, i, j, 0)) return true;
                }
            }
            return false;
        }

        private static bool Backtrack(char[][] board, string word, int i, int j, int ind)
        {
            if (ind == word.Length) return true;

            if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length || board[i][j] != word[ind]) return false;

            char temp = board[i][j];
            board[i][j] = ' ';
            bool found = Backtrack(board, word, i - 1, j, ind + 1)
                || Backtrack(board, word, i, j + 1, ind + 1)
                || Backtrack(board, word, i + 1, j, ind + 1)
                || Backtrack(board, word, i, j - 1, ind + 1);

            board[i][j] = temp;
            return found;
        }

        public static void Test()
        {
            Console.WriteLine("Testing Word Search");
            char[][] board = new char[3][];
            board[0] = new char[4] { 'A', 'B', 'C', 'E' };
            board[1] = new char[4] { 'S', 'F', 'C', 'S' };
            board[2] = new char[4] { 'A', 'D', 'E', 'E' };
            string word = "ABCCED";
            Console.WriteLine("Expected: true, Got: " + Exist(board, word));
            word = "SEE";
            Console.WriteLine("Expected: true, Got: " + Exist(board, word));
            word = "ABCB";
            Console.WriteLine("Expected: false, Got: " + Exist(board, word));
            word = "ABCCED";
            Console.WriteLine("Expected: true, Got: " + WordExists(board, word));
            word = "SEE";
            Console.WriteLine("Expected: true, Got: " + WordExists(board, word));
            word = "ABCB";
            Console.WriteLine("Expected: false, Got: " + WordExists(board, word));
        }

        public static bool WordExists(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == word[0] && BacktrackWord(board, word, i, j, 0)) return true;
                }
            }
            return false;
        }
        public static bool BacktrackWord(char[][] board, string word, int i, int j, int count) {
            if (word.Length == count) return true;
            
            if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length || board[i][j] != word[count]) return false;

            char temp = board[i][j];
            board[i][j] = ' ';
            count++;
            bool found = BacktrackWord(board, word, i-1, j, count)
                || BacktrackWord(board, word, i, j+1, count)
                || BacktrackWord(board, word, i+1, j, count)
                || BacktrackWord(board, word, i, j-1, count);
            board[i][j] = temp;
            return found;
        }
    }
}
