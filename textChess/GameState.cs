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
        1. add logic for the game
        2. 
        */

        private string[][] board;
        private char turn;
        private King W;
        private King B;
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
            W = new King('w');
            B = new King('b');
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
            else if (currentPiece[1].Equals('Q')) legalMoves = Queen.FindLegalMoves(getBoard(), startFile, startRow, turn);

            if (legalMoves.Count() == 0) { Console.WriteLine("There are no leagal moves for this piece"); return new List<string>(); }
            return legalMoves;
 
        }

        //checks if the current players turn is in check, in order to display it in the console 
        public bool isCheck(string[][] board, char turn)
        {
            //set values
            int fileOfKing, rowOfKing;
            if (turn.Equals('w')) { fileOfKing = (W.getFile()); rowOfKing = (W.getRow()); }
            else { fileOfKing = (B.getFile()); rowOfKing = (B.getRow()); }

            //check for attacking pieces
            //rooks or queens
            int file = fileOfKing - 1;
            //as far to the right
            while (file < 7)
            {
                file++;
                if (!board[rowOfKing - 1][file][0].Equals(turn) && board[rowOfKing - 1][file][1].Equals('R') || board[rowOfKing - 1][file][1].Equals('Q')) return true;
            }
            file = fileOfKing - 1;
            //as far to the left
            while (file > 0)
            {
                file--;
                if (!board[rowOfKing - 1][file][0].Equals(turn) && board[rowOfKing - 1][file][1].Equals('R') || board[rowOfKing - 1][file][1].Equals('Q')) return true;
            }
            int row = rowOfKing - 1;
            //as far up
            while (row > 0)
            {
                row--;
                if (!board[row][fileOfKing - 1][0].Equals(turn) && board[row][fileOfKing - 1][1].Equals('R') || board[row][fileOfKing - 1][1].Equals('Q')) return true;
            }
            row = rowOfKing - 1;
            //as far down
            while (row > 7)
            {
                row++;
                if (!board[row][fileOfKing - 1][0].Equals(turn) && board[row][fileOfKing - 1][1].Equals('R') || board[row][fileOfKing - 1][1].Equals('Q')) return true;
            }

            //bishops or Queens

            row = rowOfKing - 1;
            file = fileOfKing - 1;
            //top right
            while (row > 0 && file < 7)
            {
                row--;
                file++;
                if (!board[row][file][0].Equals(turn) && board[row][file][1].Equals('Q') || board[row][file][1].Equals('B')) return true;
            }
            //top left
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (row > 0 && file > 0)
            {
                row--;
                file--;
                if (!board[row][file][0].Equals(turn) && board[row][file][1].Equals('Q') || board[row][file][1].Equals('B')) return true;
            }
            //bottom left
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (file > 7 && row > 0)
            {
                file--;
                row++;
                if (!board[row][file][0].Equals(turn) && board[row][file][1].Equals('Q') || board[row][file][1].Equals('B')) return true;
            }
            //bottom right
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (row < 7 && file < 7)
            {
                file++;
                row++;
                if (!board[row][file][0].Equals(turn) && board[row][file][1].Equals('Q') || board[row][file][1].Equals('B')) return true;
            }

        }

        //this will based off the previous move if the person whos turn is passed is in check
        public bool isCheck(string[][] tempBoard, char turn, int startFile, int startRow, int endFile, int endRow)
        {

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
