using System;
using System.Text;
using Chess.ObjectPackage;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Chesspacito"; 
            Game game = new Game();
            while (!game.Over)
            {
                game.nextTurn();
            }
        }
    }
}
