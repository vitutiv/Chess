using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.ObjectPackage;

namespace Chess.PiecePackage
{
    abstract class Piece
    {
        public ConsoleColor Color { get; protected set; }
        public int MoveCount { get; protected set; } = 0;
        public String Symbol { get; protected set; }
        public Board Board { get; protected set; }
        public Position Position { get; protected set; }
        public Piece(ConsoleColor color, Board board, Position position)
        {
            Color = color;
            Board = board;
            Position = position;
        }
        public Piece(ConsoleColor color, Board board, Position position, String unicode) : this(color, board, position)
        {
            Symbol = unicode;
        }
        public override string ToString()
        {
            return Symbol;
        }
        public abstract bool[,] AvailableMoves();
        public bool IsMovable()
        {
            bool[,] _tiles = AvailableMoves();
            for (int y = 0; y < Board.Height; y++)
            {
                for (int x = 0; x < Board.Width; x++)
                {
                    if (_tiles[x,y])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void IncrementMoveCount()
        {
            ++MoveCount;
        }
        public Position Move(Position position)
        {
            if(AvailableMoves()[position.X, position.Y])
            {
                Position = position;
            }
            return Position;
        }
    }
}