using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class King
    {
        private int row;
        private int file;
        public King(char turn)
        {
            if (turn.Equals('w'))
            {
                this.row = 7;
                this.file = 4;
            }
            else if (turn.Equals('b'))
            {
                this.row = 0;
                this.file = 4;
            }
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
