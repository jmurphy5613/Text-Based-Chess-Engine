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
                //get info
                game.toString();
                int startFile, startRow;
                Console.WriteLine("Enter the file of the piece you would like to move");
                startFile = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter the row of the piece you would like to move");
                startRow = Convert.ToInt16(Console.ReadLine());

                //generate legal moves
                game.FindLegalMoves(game.getBoard(), startFile, startRow)
            }

        }
    }
}
