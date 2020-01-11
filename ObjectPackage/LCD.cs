using Chess.BoardPackage;
using Chess.PiecePackage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ObjectPackage
{
    class LCD
    {
        public static void printBoard(Board board)
        {
            printBoard(board, new bool[board.Width,board.Height]);
        }

        public static void printBoard(Board board, bool[,] validMovements)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    Piece piece = board.GetPiece(new Position(x, y));
                    Console.BackgroundColor = ConsoleColor.White;
                    if ((x + y) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    if (validMovements[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    if (piece != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (validMovements[x, y])
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (piece.Color == ConsoleColor.Black)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.Write(piece.ToString() + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" " + (y+1));
            }
            Console.WriteLine("a b c d e f g h");
        }
    }
}
