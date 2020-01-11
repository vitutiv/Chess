using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage

{
    class PieceKnight : Piece
    {
        public PieceKnight(ConsoleColor color, Board board, Position position) : base(color, board, position)
        {
            if (Color == ConsoleColor.Black)
            {
                Symbol = "♞";
            }
            else if (Color == ConsoleColor.White)
            {
                Symbol = "♘";
            }
        }
        public override bool[,] AvailableMoves()
        {
            bool[,] availableMoves = new bool[Board.Width, Board.Height];
            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    int relativeX = Math.Abs(Position.X - x);
                    int relativeY = Math.Abs(Position.Y - y);
                    if ( (relativeX == 2 ^ relativeY == 2) && (relativeX == 1 ^ relativeY == 1) )
                    {
                        Piece testPiece = Board.GetPiece(new Position(x, y));
                        if (testPiece == null || testPiece.Color != Color)
                        {
                            availableMoves[x, y] = true;
                        }
                    }
                }
            }
            return availableMoves;
        }
    }
}
