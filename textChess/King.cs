using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class King
    {
        //1 indexed
        private int row;
        private int file;
        public King(char turn)
        {
            if (turn.Equals('w'))
            {
                this.row = 8;
                this.file = 5;
            }
            else if (turn.Equals('b'))
            {
                this.row = 1;
                this.file = 5;
            }
        }

        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            List<string> firstMoves = new List<string>();
            if (startFile < 8) firstMoves.Add((startFile + 1) + "," + startRow);
            if (startFile > 1) firstMoves.Add((startFile - 1) + "," + startRow);
            if (startRow < 8) firstMoves.Add(startFile + "," + (startRow + 1));
            if (startRow > 1) firstMoves.Add(startFile + "," + (startRow - 1));

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

        public int getRow()
        {
            return row;
        }

        public int getFile()
        {
            return file;
        }

        public void setRow(int newRow)
        {
            row = newRow;
        }

        public void setFile(int newFile)
        {
            file = newFile;
        }
    }
}
