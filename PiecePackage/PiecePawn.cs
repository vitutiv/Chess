using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage

{
    class PiecePawn : Piece
    {
        public PiecePawn(ConsoleColor color, Board board, Position position) : base(color, board, position)
        {
            if (Color == ConsoleColor.Black)
            {
                Symbol = "♟";
            }
            else if (Color == ConsoleColor.White)
            {
                Symbol = "♙";
            }
        }
        public override bool[,] AvailableMoves()
        {
            bool[,] availableMovements = new bool[Board.Width, Board.Height];

            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    int relativeX = x - Position.X; // How far is this position from piece horizontally?
                    int relativeY = y - Position.Y; // How far is this position from piece vertically?
                    int moveWay = 1;
                    if (Color == ConsoleColor.White)
                    {
                        moveWay = -1;
                    }
                    if (relativeX == 0 && ( relativeY * moveWay == 1 || ( MoveCount == 0  && relativeY * moveWay == 2 ) ) ) //Check if this tile is directelly (1 or 2 tiles, if first movement) in front from piece)
                    {
                        if (Board.GetPiece(new Position(x, y)) == null)
                        {
                            availableMovements[x, y] = true;
                        }
                    }
                    if (Math.Abs(relativeX) == 1 && relativeY * moveWay == 1)
                    {
                        if (Board.GetPiece(new Position(x, y)) != null)
                        {
                            if (Color != Board.GetPiece(new Position(x, y)).Color){
                                availableMovements[x, y] = true;
                            }
                        }
                    }
                }
            }
            return availableMovements;
        }
    }
}