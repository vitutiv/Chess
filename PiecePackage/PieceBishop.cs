using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage

{
    class PieceBishop : Piece
    {
        public PieceBishop(ConsoleColor color, Board board, Position position) : base(color, board, position) {
            if (Color == ConsoleColor.Black)
            {
                Symbol = "♝";
            }
            else if (Color == ConsoleColor.White)
            {
                Symbol = "♗";
            }
        }
        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovements = new bool[Board.Width, Board.Height];
            bool[,] isDiagonalFree = new bool[2, 2]; //Tells the program if the diagonal is free (no other piece is on the way)
            //Initializing all diagonals to free
            for (int p = 0; p < isDiagonalFree.GetLength(0); p++)
            {
                for (int m = 0; m < isDiagonalFree.GetLength(1); m++)
                {
                    isDiagonalFree[m, p] = true;
                }
            }

            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    int relativeX = Math.Abs(x - Position.X); //How far is this position from piece horizontally? Absolute value
                    int relativeY = Math.Abs(y - Position.Y); //How far is this position from piece vertically? Absolute value

                    //if ((x == Position.X + i || x == Position.X - i) && (y == Position.Y + i || y == Position.Y - i)) -- A dumber way to do it but needs a for loop
                    if (relativeX == relativeY) //Check if this tile is diagonally located from piece
                    {
                        byte diagonalX = 0;
                        byte diagonalY = 0;
                        if (x == Position.X - relativeX)
                        {
                            diagonalX = 1;
                        }
                        if (y == Position.Y - relativeY)
                        {
                            diagonalY = 1;
                        }
                        if (isDiagonalFree[diagonalX, diagonalY]) // If the diagonal is free (no piece between piece and tile)
                        {
                            availableMovements[x, y] = true;
                            if (Board.GetPiece(new Position(x, y)) != null) // If there is a piece in this tile
                            {
                                if (Board.GetPiece(new Position(x,y)).Color == Color) // If this piece is from the same team
                                {
                                    availableMovements[x, y] = false; // Mark the tile as invalid
                                }
                                isDiagonalFree[diagonalX, diagonalY] = false; // Mark the diagonal as not free
                            }
                        }
                    }
                }
            }
            return availableMovements;
        }
    }
}