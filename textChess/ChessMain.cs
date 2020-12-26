using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class ChessMain
    {
        //This will maintain the acutal game element

        /*
        Things that should happen - 
        1. the board in printed
        2. take in what piece that the current player wants to be moved
        3. generate legal moves for that piece
        4. make the move slected
        5. check for checks or checkmates
        */


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to a text chess engine\n\n");
            GameState game = new GameState();
            bool gameOver = false;
            while(!gameOver)
            {
                if (game.isCheckmate(game.getBoard(), game.getTurn(), game))
                {
                    if (game.getTurn().Equals('w')) Console.WriteLine("Black wins!");
                    else Console.WriteLine("White wins!");
                }


                bool foundMoves = false;
                List<string> legalMoves = new List<string>();
                int startFile, startRow;

                //generate legal moves and make the move
                while (!foundMoves)
                {
                    //get info
                    game.toString();
                    Console.WriteLine("Enter the file of the piece you would like to move");
                    startFile = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter the row of the piece you would like to move");
                    startRow = Convert.ToInt16(Console.ReadLine());


                    legalMoves = game.FindLegalMoves(game.getBoard(), startFile, startRow, game.getTurn(), game);
                    if (legalMoves.Count() != 0) //has legal moves
                    {
                        for (int i = 0; i < legalMoves.Count(); i++)
                        {
                            Console.WriteLine(legalMoves[i]);
                        }
                        foundMoves = true;
                    }
                    else //no legal moves
                    {
                        Console.WriteLine();
                    }
                    if(foundMoves)
                    {
                        Console.WriteLine("Select which move you would like to pick 1...N");
                        int index = Convert.ToInt32(Console.ReadLine());

                        int endRow, endFile;
                        string move = legalMoves[index - 1];
                        var x = move.Split(',');
                        endFile = Int32.Parse(x[0]);
                        endRow = Int32.Parse(x[1]);

                        game.Move(game.getBoard(), startFile, startRow, endFile, endRow);
                    }
                }

            }

        }
    }
}
