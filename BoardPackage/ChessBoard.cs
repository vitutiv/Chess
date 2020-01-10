using System;
using System.Collections.Generic;
using System.Text;
using Chess.PiecePackage;
using Chess.ObjectPackage;

namespace Chess.BoardPackage
{
    class ChessBoard : Board
    {
        public ChessBoard() : base(8, 8)
        {
            ConsoleColor[] colors = { ConsoleColor.Black, ConsoleColor.White };
            /* 
             * "I'M SO FANCY, YOU ALREADY KNOW" 
             * AN USELESS BUT COOL WAY OF INITIALIZING THE BOARD WITH PIECES USING FOR LOOPS
             */
            for (int team = 0; team < 2; team ++)
            {
                for (int y = 0; y < 2; y++)
                {
                    int mirrorY = Math.Abs((7 * team) - y);
                    for (int x = 0; x < 4; x++)
                    {
                        switch (y)
                        {
                            case 0:
                                switch (x)
                                {
                                    case 0:
                                        _tiles[x, mirrorY] = new PieceRook(colors[team], this, new Position(x, mirrorY));
                                        _tiles[7 - x, mirrorY] = new PieceRook(colors[team], this, new Position(7 - x, mirrorY));
                                        break;
                                    case 1:
                                        _tiles[x, mirrorY] = new PieceKnight(colors[team], this, new Position(x, mirrorY));
                                        _tiles[7 - x, mirrorY] = new PieceKnight(colors[team], this, new Position(7 - x, mirrorY));
                                        break;
                                    case 2:
                                        _tiles[x, mirrorY] = new PieceBishop(colors[team], this, new Position(x, mirrorY));
                                        _tiles[7 - x, mirrorY] = new PieceBishop(colors[team], this, new Position(7 - x, mirrorY));
                                        break;
                                    case 3:
                                        _tiles[x, mirrorY] = new PieceQueen(colors[team], this, new Position(x, mirrorY));
                                        _tiles[7 - x, mirrorY] = new PieceKing(colors[team], this, new Position(7 - x, mirrorY));
                                        break;
                                }
                                break;
                            case 1:
                                _tiles[x, mirrorY] = new PiecePawn(colors[team], this, new Position (x, mirrorY) );
                                _tiles[7 - x, mirrorY] = new PiecePawn(colors[team], this, new Position(7 - x, mirrorY));
                                break;
                        }
                    }
                }
            }
        }
    }
}
