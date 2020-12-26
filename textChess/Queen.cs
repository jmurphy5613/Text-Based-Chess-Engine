using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Queen
    {
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            List<string> firstMoves = new List<string>();
            List<string> firstMoves2 = new List<string>();
            firstMoves = Bishop.FindLegalMoves(board, startFile, startRow, turn, game);
            firstMoves2 = Rook.FindLegalMoves(board, startFile, startRow, turn, game);
            firstMoves.AddRange(firstMoves2);

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
