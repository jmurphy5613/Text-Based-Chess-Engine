using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Bishop
    {
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn)
        {
            List<string> moves = new List<string>();
            int row = startRow - 1;
            int file = startFile - 1;
            //top right
            while(row > 0 && file < 7 )
            {
                row--;
                file++;
                if (board[row][file].Equals("--")) moves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
            }
            //top left
            row = startRow - 1;
            file = startFile - 1;
            while(row > 0 && file > 0)
            {
                row--;
                file--;
                if (board[row][file].Equals("--")) moves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (row + 1)); break; }
                else break;

            }
            //bottom left
            row = startRow - 1;
            file = startFile - 1;
            while (file > 7 && row > 0)
            {
                file--;
                row++;
                if (board[row][file].Equals("--")) moves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
            }
            //bottom right
            row = startRow - 1;
            file = startFile - 1;
            while (row < 7 && file < 7)
            {
                file++;
                row++;
                if (board[row][file].Equals("--")) moves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { moves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
            }
            return moves;
        }
    }
}
