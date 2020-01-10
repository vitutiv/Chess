using System;
using System.Text;
using Chess.ObjectPackage;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Game game = new Game();
            while (!game.Over)
            {
                game.nextTurn();
            }
        }
    }
}
