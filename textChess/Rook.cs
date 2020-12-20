using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    class Rook
    {
        //Finds legal moves for the Rook
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn)
        {
            List<string> moves = new List<string>();
            int file = startFile - 1;
            //as far to the right
            while (file < 7)
            {
                file++;
                if (board[startRow - 1][file].Equals("--")) moves.Add((file + 1) + "," + (startRow));
                else if (!board[startRow - 1][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (startRow)); break; }
                else break;
            }
            file = startFile - 1;
            //as far to the left
            while (file > 0)
            {
                file--;
                if (board[startRow - 1][file].Equals("--")) moves.Add((file + 1) + "," + (startRow));
                else if (!board[startRow - 1][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (startRow)); break; }
                else break;
            }
            int row = startRow - 1;
            //as far up
            while (row > 0)
            {
                row--;
                if (board[row][startFile - 1].Equals("--")) moves.Add((startFile) + "," + (row + 1));
                else if (!board[row][startFile - 1][0].Equals(turn)) { moves.Add((startFile) + "," + (row + 1)); break; }
                else break;
            }
            //as far down
            while (row > 7)
            {
                row++;
                if (board[row][startFile - 1].Equals("--")) moves.Add((startFile) + "," + (row + 1));
                else if (!board[row][startFile - 1][0].Equals(turn)) { moves.Add((startFile) + "," + (row + 1)); break; }
                else break;
            }
            return moves;
        }
    }
}
