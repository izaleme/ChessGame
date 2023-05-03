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
                    Console.Clear();
                    Screen.PrintBoard(match.board);
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.DoMovement(origin, destiny);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        #endregion
    }
}