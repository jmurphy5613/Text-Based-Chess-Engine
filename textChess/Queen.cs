using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Queen
    {
        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn)
        {
            List<string> moves = new List<string>();
            List<string> moves2 = new List<string>();
            moves = Bishop.FindLegalMoves(board, startFile, startRow, turn);
            moves2 = Rook.FindLegalMoves(board, startFile, startRow, turn);
            moves.AddRange(moves2);
            return moves;
        }
    }
}
