using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.PiecePackage;
namespace Chess.ObjectPackage
{
    class Game
    {
        public bool Over { get; protected set; } = false;
        public ChessBoard Board { get; protected set; }
        
        public Game()
        {
            Board = new ChessBoard();
        }
        public void nextTurn()
        {
            Console.Clear();
            Console.WriteLine(Board.ToString());
            Console.Write("Choose a piece: ");
            String position = Console.ReadLine();
            if (int.Parse(position[0].ToString()) < Board.Height)
            {
                Console.Write("Choose a movement: ");
                String target = Console.ReadLine();
            }
        }
    }
}
