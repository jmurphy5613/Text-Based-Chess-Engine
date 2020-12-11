using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class GameState 
    {
        private string[][] board;
        private char turn;
        public GameState()
        {
            board = new string[8][]; 
            //This is the first state of the board
            board[0] = new string[8] { "bR", "bN", "bB", "bQ", "bK", "bB", "bN", "bR" };
            board[1] = new string[8] { "bP", "bP", "bP", "bP", "bP", "bP", "bP", "bP" };
            board[2] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            board[3] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            board[4] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            board[5] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            board[6] = new string[8] { "wP", "wP", "wP", "wP", "wP", "wP", "wP", "wP" };
            board[7] = new string[8] { "wR", "wN", "wB", "wQ", "wK", "wB", "wN", "wR" };
            //sets the current turn to white
            turn = 'w';
        }

        public string[][] getBoard()
        {
            return board;
        }

        //Move function
        public void Move(string[][] board, int startFile, int startRow, int endFile, int endRow)
        {
            //This function is not designed to check for legal moves, or to check if the current move causes check or checkmate
            string piece = board[startRow - 1][startFile - 1];
            board[endRow - 1][endFile - 1] = piece;
            board[startRow - 1][endFile - 1] = "--";
        }
        //Find legal moves function
        public string[] FindLegalMoves(string[][] board, int startFile, int startRow)
        {
            //This function will select a current piece and return a list of all of its legal moves
            //This function will call a method from the specific piece class to generate all the legal moves for that certain piece
            return new string[5];
        }

        public void toString()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
