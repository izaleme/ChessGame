using System;
using board;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        #region  Methods

        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.board.Piece(origin).PossibleMoves();  // Pega os possíveis movimentos da peça escolhida

                        Console.Clear();
                        Screen.PrintBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinyPosition(origin, destiny);

                        match.DoMovement(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        #endregion
    }
}