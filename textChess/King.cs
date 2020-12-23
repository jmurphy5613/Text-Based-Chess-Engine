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

        public static List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn)
        {
            List<string> moves = new List<string>();
            if (startFile < 8) moves.Add((startFile + 1) + "," + startRow);
            if (startFile > 1) moves.Add((startFile - 1) + "," + startRow);
            if (startRow < 8) moves.Add(startFile + "," + (startRow + 1));
            if (startRow > 1) moves.Add(startFile + "," + (startRow - 1));
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
