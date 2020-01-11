using System;
using System.Collections.Generic;
using System.Text;
using Chess.BoardPackage;
using Chess.PiecePackage;
namespace Chess.ObjectPackage
{
    class Game
    {
        public int Turn { get; protected set; } = 0; //Turn's number (EVEN = black, ODD = WHITE).
        public ConsoleColor[] teams = { ConsoleColor.Black, ConsoleColor.White }; // Team colors that are used in the whole game (Black, White).
        public bool Over { get; protected set; } = false; // Game over?
        public ChessBoard Board { get; protected set; } // Game board
        public Game() //Creates a new game
        {
            Board = new ChessBoard();
        }
        public bool nextTurn() //Next turn
        {
            Console.Clear();
            LCD.printBoard(Board);
            Console.WriteLine("Turn of: " + teams[Turn % 2].ToString());
            Console.Write("Choose a piece (a-h)(1-8): ");
            String position = Console.ReadLine();
            int x = char.ToUpper(position[0]) - 65;
            int y = int.Parse(position[1].ToString()) - 1;
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
                            Console.Write("Move " + selectedPiece.Symbol + " in " + position + " to: ");
                            String target = Console.ReadLine();
                            x = char.ToUpper(target[0]) - 65;
                            y = int.Parse(target[1].ToString()) - 1;
                            if (x < Board.Width && y < Board.Height)
                            {
                                Position oldPosition = selectedPiece.Position;
                                newPosition = new Position(x, y);
                                if (selectedPiece.Move(newPosition) == newPosition)
                                {
                                    Board.MovePiece(oldPosition, newPosition);
                                    ++Turn;
                                    return true;
                                }
                                else
                                {
                                    errorMessage = "This is not a valid movement for the selected piece.";
                                }
                            }
                            else
                            {
                                errorMessage = "Please write a letter (a-h) and a number (1-8). Ex: a8";
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
                errorMessage = "Please write a letter (a-h) and a number (1-8). Ex: h1";
            }
            Console.WriteLine(errorMessage);
            Console.ReadKey();
            return false;
        }
    }
}
