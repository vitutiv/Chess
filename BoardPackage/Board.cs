using System;
using System.Collections.Generic;
using System.Text;
using Chess.PiecePackage;
using Chess.ObjectPackage;

namespace Chess.BoardPackage
{
    abstract class Board
    {
        protected Piece[,] _tiles;
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public Board(int width, int height)
        {
            _tiles = new PiecePackage.Piece[width, height];
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            String boardString = "";
            for (int y = 0; y < _tiles.GetLength(1); y++)
            {
                for (int x = 0; x < _tiles.GetLength(0); x++)
                {
                    if (_tiles[x,y] != null)
                    {
                        boardString += _tiles[x, y].ToString();
                    }
                    else
                    {
                        boardString += " ";
                    }
                }
                boardString += "\n";
            }
            return boardString;
        }
        public bool TileUsed(Position p)
        {
            return _tiles[p.X, p.Y] == null;
        }
        public Piece GetPiece(Position p)
        {
            return _tiles[p.X, p.Y];
        }
        public Piece RemovePiece(Position p)
        {
            PiecePackage.Piece pieceSelected = GetPiece(p);
            if (pieceSelected == null)
            {
                return null;
            }
            _tiles[p.X, p.Y] = null;
            return pieceSelected;
        }
        public Piece MovePiece(Position oldPosition, Position newPosition)
        {
            _tiles[newPosition.X, newPosition.Y] = GetPiece(oldPosition);
            RemovePiece(oldPosition);
            return GetPiece(newPosition);
        }
    }
}