using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Pawn
    {
        
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            //two possible ways to generate moves corresponding to the current players turn.
            List<string> firstMoves = new List<string>();
            //The moves will be returned in a non-zero indexing
            if(turn.Equals('w'))
            {
                if (startRow - 1 == 6 && board[(startRow - 1) - 1][startFile - 1].Equals("--") && board[(startRow - 1) - 2][startFile - 1].Equals("--")) { firstMoves.Add(startFile + "," + (startRow - 2)); firstMoves.Add(startFile + "," + (startRow - 1)); }
                else if (board[(startRow - 1) - 1][startFile - 1].Equals("--")) firstMoves.Add(startFile + "," + (startRow - 1));

                if (startFile != 1 && !board[startRow - 2][startFile - 2].Equals("--") && !board[startRow - 2][startFile - 2][0].Equals(turn)) firstMoves.Add((startFile - 1) + "," + (startRow - 1));
                if (startFile != 8 && !board[startRow - 2][startFile].Equals("--") && !board[startRow - 2][startFile][0].Equals(turn)) firstMoves.Add((startFile + 1) + "," + (startRow - 1));
            }
            else if(turn.Equals('b'))
            {
                if (startRow - 1 == 1 && board[(startRow - 1) + 1][startFile - 1].Equals("--") && board[(startRow - 1) + 2][startFile - 1].Equals("--")) { firstMoves.Add(startFile + "," + (startRow + 2)); firstMoves.Add(startFile + "," + (startRow + 1)); }
                else if (board[(startRow - 1) + 1][startFile - 1].Equals("--")) firstMoves.Add(startFile + "," + (startRow + 1));

                if (startFile != 8 && !board[startRow][startFile].Equals("--") && !board[startRow][startFile][0].Equals(turn)) firstMoves.Add(startFile + "," + startRow);
                if (startFile != 1 && !board[startRow][startFile - 2].Equals("--") && !board[startRow][startFile - 2][0].Equals(turn)) firstMoves.Add((startFile - 1) + "," + (startRow + 1));
            }

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
