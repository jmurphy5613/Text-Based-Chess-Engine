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
        2. fix is check method!!!!!!!!!!
        */

        private string[][] board;
        private char turn;
        public King W;
        public King B;
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
            board[startRow - 1][startFile - 1] = "--";
        }
        //Find legal moves function
        public List<string> FindLegalMoves(string[][] board, int startFile, int startRow, char turn, GameState game)
        {
            //This function will call a method from the specific piece class to generate all the legal moves for that certain piece
            string currentPiece = board[startRow - 1][startFile - 1];
            List<string> legalMoves = new List<string>();

            //if the piece that is generating moves does not belong to the current turn, then it will return with an error
            if (currentPiece.Equals("--")) { Console.WriteLine("There is no piece in that location!"); return new List<string>(); }
            else if (!currentPiece[0].Equals(turn)) { Console.WriteLine("That is not your piece!"); return new List<string>(); }
            else if (currentPiece[1].Equals('P')) legalMoves = Pawn.FindLegalMoves(getBoard(), startFile, startRow, turn, game);
            else if (currentPiece[1].Equals('R')) legalMoves = Rook.FindLegalMoves(getBoard(), startFile, startRow, turn, game);
            else if (currentPiece[1].Equals('N')) legalMoves = Knight.FindLegalMoves(getBoard(), startFile, startRow, turn, game);
            else if (currentPiece[1].Equals('B')) legalMoves = Bishop.FindLegalMoves(getBoard(), startFile, startRow, turn, game);
            else if (currentPiece[1].Equals('Q')) legalMoves = Queen.FindLegalMoves(getBoard(), startFile, startRow, turn, game);
            else if (currentPiece[1].Equals('K')) legalMoves = King.FindLegalMoves(getBoard(), startFile, startRow, turn, game);

            if (legalMoves.Count() == 0) return new List<string>(); 
            return legalMoves;
 
        }

        //checks if the current players turn is in check, in order to display it in the console 
        public bool isCheck(string[][] board, char turn)
        {
            //set values
            int fileOfKing, rowOfKing;
            if (turn.Equals('w')) { fileOfKing = W.getFile(); rowOfKing = W.getRow(); }
            else { fileOfKing = B.getFile(); rowOfKing = B.getRow(); }

            //check for attacking pieces
            //rooks or queens
            int file = fileOfKing - 1;
            //as far to the right
            while (file < 7)
            {
                file++;
                if (!board[rowOfKing - 1][file][0].Equals(turn) && (board[rowOfKing - 1][file][1].Equals('R') || board[rowOfKing - 1][file][1].Equals('Q'))) return true;
                else if (board[rowOfKing - 1][file][0].Equals(turn) || !board[rowOfKing - 1][file][0].Equals(turn)) break;
            }
            file = fileOfKing - 1;
            //as far to the left
            while (file > 0)
            {
                file--;
                if (!board[rowOfKing - 1][file][0].Equals(turn) && (board[rowOfKing - 1][file][1].Equals('R') || board[rowOfKing - 1][file][1].Equals('Q'))) return true;
                else if (board[rowOfKing - 1][file][0].Equals(turn) || !board[rowOfKing - 1][file][0].Equals(turn)) break;
            }
            int row = rowOfKing - 1;
            //as far up
            while (row > 0)
            {
                row--;
                if (!board[row][fileOfKing - 1][0].Equals(turn) && (board[row][fileOfKing - 1][1].Equals('R') || board[row][fileOfKing - 1][1].Equals('Q'))) return true;
                else if (board[row][fileOfKing - 1][0].Equals(turn) || !board[rowOfKing - 1][file][0].Equals(turn)) break;
            }
            row = rowOfKing - 1;
            //as far down
            while (row > 7)
            {
                row++;
                if (!board[row][fileOfKing - 1][0].Equals(turn) && (board[row][fileOfKing - 1][1].Equals('R') || board[row][fileOfKing - 1][1].Equals('Q'))) return true;
                else if (board[row][fileOfKing - 1][0].Equals(turn) || !board[rowOfKing - 1][file][0].Equals(turn)) break;
            }

            //bishops or Queens

            row = rowOfKing - 1;
            file = fileOfKing - 1;
            //top right
            while (row > 0 && file < 7)
            {
                row--;
                file++;
                if (!board[row][file][0].Equals(turn) && (board[row][file][1].Equals('Q') || board[row][file][1].Equals('B'))) return true;
                else if (board[row][file][0].Equals(turn) || !board[row][file][0].Equals(turn)) break;
            }
            //top left
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (row > 0 && file > 0)
            {
                row--;
                file--;
                if (!board[row][file][0].Equals(turn) && (board[row][file][1].Equals('Q') || board[row][file][1].Equals('B'))) return true;
                else if (board[row][file][0].Equals(turn) || !board[row][file][0].Equals(turn)) break;
            }
            //bottom left
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (row < 7 && file > 0)
            {
                file--;
                row++;
                if (!board[row][file][0].Equals(turn) && (board[row][file][1].Equals('Q') || board[row][file][1].Equals('B'))) return true;
                else if (board[row][file][0].Equals(turn) || !board[row][file][0].Equals(turn)) break;
            }
            //bottom right
            row = rowOfKing - 1;
            file = fileOfKing - 1;
            while (row < 7 && file < 7)
            {
                file++;
                row++;
                if (!board[row][file][0].Equals(turn) && (board[row][file][1].Equals('Q') || board[row][file][1].Equals('B'))) return true;
                else if (board[row][file][0].Equals(turn) || !board[row][file][0].Equals(turn)) break;
            }

            //knights

            if ((rowOfKing - 1) - 2 >= 0 && (fileOfKing - 1) - 1 >= 0 && !board[rowOfKing - 3][fileOfKing - 2][0].Equals(turn) && board[rowOfKing - 3][fileOfKing - 2][1].Equals('N')) return true;
            if ((fileOfKing - 1) - 2 >= 0 && (rowOfKing - 1) - 1 >= 0 && !board[rowOfKing - 2][fileOfKing - 3][0].Equals(turn) && board[rowOfKing - 2][fileOfKing - 3][1].Equals('N')) return true;
            if ((rowOfKing - 1) - 2 >= 0 && (fileOfKing - 1) + 1 <= 7 && !board[rowOfKing - 3][fileOfKing][0].Equals(turn) && board[rowOfKing - 3][fileOfKing][1].Equals('N')) return true;
            if ((fileOfKing - 1) + 2 <= 7 && (rowOfKing - 1) - 1 >= 0 && !board[rowOfKing - 2][fileOfKing + 1][0].Equals(turn) && board[rowOfKing - 2][fileOfKing + 1][1].Equals('N')) return true;
            if ((rowOfKing - 1) + 2 <= 7 && (fileOfKing - 1) + 1 <= 7 && !board[rowOfKing + 1][fileOfKing][0].Equals(turn) && board[rowOfKing + 1][fileOfKing][1].Equals('N')) return true;
            if ((fileOfKing - 1) + 2 <= 7 && (rowOfKing - 1) + 1 <= 7 && !board[rowOfKing][fileOfKing + 1][0].Equals(turn) && board[rowOfKing][fileOfKing + 1][1].Equals('N')) return true;
            if ((fileOfKing - 1) - 2 >= 0 && (rowOfKing - 1) + 1 <= 7 && !board[rowOfKing][fileOfKing - 3][0].Equals(turn) && board[rowOfKing][fileOfKing - 3][1].Equals('N')) return true; 

            //pawns

            if(turn.Equals('w'))
            {
                if (fileOfKing != 1 && !board[rowOfKing - 2][fileOfKing - 2][0].Equals(turn) && board[rowOfKing - 2][fileOfKing - 2][1].Equals('P')) return true;
                if (fileOfKing != 8 && !board[rowOfKing - 2][fileOfKing][0].Equals(turn) && board[rowOfKing - 2][fileOfKing][1].Equals('P')) return true;
            }
            else
            {
                if (fileOfKing != 1 && !board[rowOfKing][fileOfKing - 2][0].Equals(turn) && board[rowOfKing][fileOfKing - 2][1].Equals('P')) return true;
                if (fileOfKing != 8 && !board[rowOfKing][fileOfKing][0].Equals(turn) && board[rowOfKing][fileOfKing][1].Equals('P')) return true;
            }
            return false;
        }

        //this would check if a move will put themself in check
        //used to prune legal moves,  ex. pins, king moves, etc.
        public bool isCheck(string[][] board, char turn, int startFile, int startRow, int endFile, int endRow)
        {
            string[][] tempBoard = new string[8][];
            tempBoard[0] = new string[8] { "bR", "bN", "bB", "bQ", "bK", "bB", "bN", "bR" };
            tempBoard[1] = new string[8] { "bP", "bP", "bP", "bP", "bP", "bP", "bP", "bP" };
            tempBoard[2] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            tempBoard[3] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            tempBoard[4] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            tempBoard[5] = new string[8] { "--", "--", "--", "--", "--", "--", "--", "--" };
            tempBoard[6] = new string[8] { "wP", "wP", "wP", "wP", "wP", "wP", "wP", "wP" };
            tempBoard[7] = new string[8] { "wR", "wN", "wB", "wQ", "wK", "wB", "wN", "wR" };

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    tempBoard[i][j] = board[i][j];

            Move(tempBoard, startFile, startRow, endFile, endRow);
            return isCheck(tempBoard, turn);
        }

        public bool isCheckmate(string[][] board, char turn, GameState game)
         {
            //bruteforce solution
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    List<string> legalMoves = new List<string>();
                    string currentPiece = board[i][j];
                    if (currentPiece.Equals("--")) { continue; }
                    else if (!currentPiece[0].Equals(turn)) { continue; }        //you add 1 to the variabless to make them 1 indexed
                    else if (currentPiece[1].Equals('P')) legalMoves = Pawn.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);
                    else if (currentPiece[1].Equals('R')) legalMoves = Rook.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);
                    else if (currentPiece[1].Equals('N')) legalMoves = Knight.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);
                    else if (currentPiece[1].Equals('B')) legalMoves = Bishop.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);
                    else if (currentPiece[1].Equals('Q')) legalMoves = Queen.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);
                    else if (currentPiece[1].Equals('K')) legalMoves = King.FindLegalMoves(getBoard(), j + 1, i + 1, turn, game);

                    //check if the piece has any legal moves
                    if (legalMoves.Count() != 0) return false;
                }
            }
            return true;
        }

        public char getTurn()
        {
            return turn;
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
