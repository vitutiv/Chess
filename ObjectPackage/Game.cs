using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.PiecePackage;
namespace Chess.ObjectPackage
{
    class Game
    {
        public int Turn { get; protected set; } = 0;
        public ConsoleColor[] teams = { ConsoleColor.Black, ConsoleColor.White };
        public bool Over { get; protected set; } = false;
        public ChessBoard Board { get; protected set; }
        public Game()
        {
            Board = new ChessBoard();
        }
        public bool nextTurn()
        {
            Console.Clear();
            LCD.printBoard(Board);
            Console.WriteLine("Turn: " + teams[Turn % 2].ToString());
            Console.Write("Choose a piece (LineColumn): ");
            String position = Console.ReadLine();
            int x = int.Parse(position[1].ToString()) - 1;
            int y = int.Parse(position[0].ToString()) - 1;
            Position newPosition = new Position(x, y);
            String errorMessage;
            if (x < Board.Width && y < Board.Height)
            {
                Console.Clear();
                Piece selectedPiece = Board.GetPiece(new Position(x, y));
                if (selectedPiece != null)
                {
                    if (selectedPiece.IsMovable())
                    {
                        if (selectedPiece.Color == teams[Turn % 2])
                        {
                            LCD.printBoard(Board, selectedPiece.AvailableMoves());
                            Console.Write("Move" + selectedPiece.Symbol + " to: ");
                            String target = Console.ReadLine();
                            x = int.Parse(target[1].ToString()) - 1;
                            y = int.Parse(target[0].ToString()) - 1;
                            if (x < Board.Width && y < Board.Height)
                            {
                                Position oldPosition = selectedPiece.Position;
                                newPosition = new Position(x, y);
                                if (selectedPiece.Move(newPosition) == newPosition)
                                {
                                    Board.MovePiece(oldPosition, newPosition);
                                    return true;
                                }
                                else
                                {
                                    errorMessage = "Unexpected error";
                                }
                            }
                            else
                            {
                                errorMessage = "Please write two numbers between 1 and 8. Ex: 88";
                            }
                        }
                        else
                        {
                            errorMessage = "The selected piece isn't from your team. Please choose a piece of yours.";
                        }
                    }
                    else
                    {
                        errorMessage = "The selected piece can't be moved. Please choose another one.";
                    }
                }
                else
                {
                    errorMessage = "The selected tile is empty. Please choose a valid one.";
                }
            }
            else
            {
                errorMessage = "Please write two numbers between 1 and 8. Ex: 81";
            }
            Console.WriteLine(errorMessage);
            Console.ReadKey();
            return false;
        }
    }
}
