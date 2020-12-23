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
                if (board[row - 1][file + 1].Equals("--")) moves.Add((file + 2) + "," + row);
                else if (!board[row - 1][file + 1][0].Equals(turn)) { moves.Add((file + 2) + "," + row); break; }
                else break;
            }
            //top left
            row = startRow - 1;
            file = startFile - 1;
            while(row > 0 && file > 0)
            {
                row--;
                file--;
                if (board[row - 1][file - 1].Equals("--")) moves.Add(file + "," + row);
                else if (!board[row - 1][file - 1][0].Equals(turn)) { moves.Add(file + "," + row); break; }
                else break;

            }
            //bottom left
            row = startRow - 1;
            file = startFile - 1;
            while (file > 7 && row > 0)
            {
                file--;
                row++;
                if (board[row + 1][file - 1].Equals("--")) moves.Add(file + "," + (row + 2));
                else if (!board[row + 1][file - 1][0].Equals(turn)) { moves.Add(file + "," + (row + 2)); break; }
                else break;
            }
            //bottom right
            row = startRow - 1;
            file = startFile - 1;
            while (row < 7 && file < 7)
            {
                file++;
                row++;
                if (board[row + 1][file + 1].Equals("--")) moves.Add((file + 2) + "," + (row + 2));
                else if (!board[row + 1][file + 1][0].Equals(turn)) { moves.Add((file + 2) + "," + (row + 2)); break; }
                else break;
            }
            return moves;
        }
    }
}
