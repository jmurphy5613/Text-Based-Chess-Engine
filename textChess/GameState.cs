using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class GameState 
    {
        /*
        List of things to add - 
        1. Create a dictionary that has the corresponding letters to numbers for selecting a piece
        2. Enpassant
        */

        private string[][] board;
        private char turn;
        public GameState()                  //1,7
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
            board[7] = new string[8] { "wR", "wN", "wB", "wQ", "wK", "wB", "wN", "wR" }; //2,8
            //sets the current turn to white
            turn = 'w';
        }

        public string[][] getBoard()
        {
            return board;
        }

        public void changeTurn()
        {
            if (turn.Equals('w')) turn = 'b';
            else turn = 'w';
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
        public List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn)
        {
            //This function will call a method from the specific piece class to generate all the legal moves for that certain piece
            string currentPiece = board[startRow - 1][startFile - 1];
            List<string> legalMoves = new List<string>();

            //if the piece that is generating moves does not belong to the current turn, then it will return with an error
            if (currentPiece.Equals("--")) { Console.WriteLine("There is no piece in that location!"); return new List<string>(); }
            else if (!currentPiece[0].Equals(turn)) { Console.WriteLine("That is not your piece!"); return new List<string>(); }
            else if (currentPiece[1].Equals('P')) legalMoves = Pawn.FindLegalMoves(getBoard(), startFile, startRow, turn);
            else if (currentPiece[1].Equals('R')) legalMoves = Rook.FindLegalMoves(getBoard(), startFile, startRow, turn);
            else if (currentPiece[1].Equals('N')) legalMoves = Knight.FindLegalMoves(getBoard(), startFile, startRow, turn);
            else if (currentPiece[1].Equals('B')) legalMoves = Bishop.FindLegalMoves(getBoard(), startFile, startRow, turn);

            if (legalMoves.Count() == 0) { Console.WriteLine("There are no leagal moves for this piece"); return new List<string>(); }
            return legalMoves;
 
        }

        //Prints the board
        public void toString()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i][j] + "      ");
                }
                for (int p = 0; p < 4; p++) Console.WriteLine();
            }
        }
    }
}
