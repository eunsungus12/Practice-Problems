using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice.Top_Amazon_Questions.Design
{
    class TicTacToe
    {
        // https://leetcode.com/explore/interview/card/amazon/81/design/517/

        int[] board;
        public TicTacToe(int n)
        {
            this.board = new int[n*n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            return 1;
        }
    }
}
