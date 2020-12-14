using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textChess
{
    public class ChessMain
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            game.toString();
            Console.WriteLine("Enter the start file");
            int startFile = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the start row");
            int startRow = Convert.ToInt32(Console.ReadLine());
            List<string> list = game.FindLegalMoves(game.getBoard(), startFile, startRow, 'w');
            for (int i = 0; i < list.Count(); i++) Console.WriteLine(list[i]);
        }
    }
}
