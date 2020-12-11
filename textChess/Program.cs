using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey welcome to jChess");
            GameState game = new GameState();
            bool endGame = true;
            while(endGame)
            {
                game.toString();
                Console.WriteLine("Enter the start file");
                int startFile = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the start row");
                int startRow = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the end file");
                int endFile = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the end row");
                int endRow = Convert.ToInt32(Console.ReadLine());
                game.Move(game.getBoard(), startFile, startRow, endFile, endRow);

                Console.WriteLine("Would you like to end the game?");
                string response = Console.ReadLine();

                if (response == "yes") endGame = false;
                else continue;
            }
        }
    }
}
