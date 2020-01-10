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
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (validMovements[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    if (piece != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (validMovements[x, y])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (piece.Color == ConsoleColor.Black)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(piece.ToString() + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
