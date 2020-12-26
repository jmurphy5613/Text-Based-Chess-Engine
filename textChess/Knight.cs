using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Knight
    {
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            List<string> firstMoves = new List<string>();
            if ((startRow - 1) - 2 >= 0 && (startFile - 1) - 1 >= 0 && !board[startRow - 3][startFile - 2][0].Equals(turn)) firstMoves.Add((startFile - 1) + "," + (startRow - 2));
            if ((startFile - 1) - 2 >= 0 && (startRow - 1) - 1 >= 0 && !board[startRow - 2][startFile - 3][0].Equals(turn)) firstMoves.Add((startFile - 2) + "," + (startRow - 1));
            if ((startRow - 1) - 2 >= 0 && (startFile - 1) + 1 <= 7 && !board[startRow - 3][startFile][0].Equals(turn)) firstMoves.Add((startFile + 1) + "," + (startRow - 2));
            if ((startFile - 1) + 2 <= 7 && (startRow - 1) - 1 >= 0 && !board[startRow - 2][startFile + 1][0].Equals(turn)) firstMoves.Add((startFile + 2) + "," + (startRow - 1));
            if ((startRow - 1) + 2 <= 7 && (startFile - 1) + 1 <= 7 && !board[startRow + 1][startFile][0].Equals(turn)) firstMoves.Add((startFile + 1) + "," + (startRow + 2));
            if ((startFile - 1) + 2 <= 7 && (startRow - 1) + 1 <= 7 && !board[startRow][startFile + 1][0].Equals(turn)) firstMoves.Add((startFile + 2) + "," + (startRow + 1));
            if ((startFile - 1) - 2 >= 0 && (startRow - 1) + 1 <= 7 && !board[startRow][startFile - 3][0].Equals(turn)) firstMoves.Add((startFile - 2) + "," + (startRow + 1));

            List<string> moves = new List<string>();

            for (int i = 0; i < firstMoves.Count(); i++)
            {
                int listFile, listRow;
                var x = firstMoves[i].Split(',');
                listFile = Int32.Parse(x[0]);
                listRow = Int32.Parse(x[1]);

                if (game.isCheck(board, turn, startFile, startRow, listFile, listRow)) continue;
                else moves.Add(listFile + "," + listRow);

            }

            return moves;
        }
    }
}
