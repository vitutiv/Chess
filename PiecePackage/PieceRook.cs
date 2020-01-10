using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage

{
    class PieceRook : Piece
    {
        public PieceRook(ConsoleColor color, Board board, Position position) : base(color, board, position) {
            if (Color == ConsoleColor.Black)
            {
                Symbol = "♜";
            }
            else if (Color == ConsoleColor.White)
            {
                Symbol = "♖";
            }
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] availableMoves = new bool[Board.Width, Board.Height];
            bool[,] isWayFree = new bool[2, 2]; //Tells the program if the way is free (no other piece is on the way)
            //Initializing all ways to free
            for (int p = 0; p < isWayFree.GetLength(0); p++)
            {
                for (int m = 0; m < isWayFree.GetLength(1); m++)
                {
                    isWayFree[m, p] = true;
                }
            }

            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    int relativeX = Math.Abs(x - Position.X); // How far is this position from piece horizontally? Absolute value
                    int relativeY = Math.Abs(y - Position.Y); //How far is this position from piece vertically? Absolute value

                    if (relativeX == 0 ^ relativeY == 0) // Check if this tile is in same line XOR column of the piece
                    {
                        byte wayX = 0;
                        byte wayY = 0;
                        if (x == Position.X - relativeX)
                        {
                            wayX = 1;
                        }
                        if (y == Position.Y - relativeY)
                        {
                            wayY = 1;
                        }
                        if (isWayFree[wayX, wayY])
                        {
                            availableMoves[x, y] = true;
                            if (Board.GetPiece(new Position(x, y)) != null)
                            {
                                isWayFree[wayX, wayY] = false;
                            }
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}