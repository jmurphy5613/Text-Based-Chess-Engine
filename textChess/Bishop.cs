using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Bishop
    {
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            List<string> firstMoves = new List<string>();
            int row = startRow - 1;
            int file = startFile - 1;
            //top right
            while(row > 0 && file < 7 )
            {
                row--;
                file++;
                if (board[row][file].Equals("--")) firstMoves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { firstMoves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
            }
            //top left
            row = startRow - 1;
            file = startFile - 1;
            while(row > 0 && file > 0)
            {
                row--;
                file--;
                if (board[row][file].Equals("--")) firstMoves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { firstMoves.Add((file + 1) + "," + (row + 1)); break; }
                else break;

            }
            //bottom left
            row = startRow - 1;
            file = startFile - 1;
            while (file > 0 && row < 7)
            {
                file--;
                row++;
                if (board[row][file].Equals("--")) firstMoves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { firstMoves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
            }
            //bottom right
            row = startRow - 1;
            file = startFile - 1;
            while (row < 7 && file < 7)
            {
                file++;
                row++;
                if (board[row][file].Equals("--")) firstMoves.Add((file + 1) + "," + (row + 1));
                else if (!board[row][file][0].Equals(turn)) { firstMoves.Add((file + 1) + "," + (row + 1)); break; }
                else break;
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
