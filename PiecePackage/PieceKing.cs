using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage

{
    class PieceKing : Piece
    {
        public PieceKing(ConsoleColor color, Board board, Position position) : base(color, board, position)
        {
            if (Color == ConsoleColor.Black)
            {
                Symbol = "♚";
            }
            else if (Color == ConsoleColor.White)
            {
                Symbol = "♔";
            }
        }
        public override bool[,] AvailableMoves()
        {
            return new bool[Board.Width, Board.Height]; //NOT IMPLEMENTED  YET;
        }
    }
}
