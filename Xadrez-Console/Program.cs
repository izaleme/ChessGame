using System;
using board;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        #region  Methods

        static void Main(string[] args)
        {
            try
            {
                Board tab = new Board(8, 8);

                tab.PutPieces(new Tower(tab, Color.Black), new Position(0, 0));
                tab.PutPieces(new Tower(tab, Color.Black), new Position(1, 3));
                tab.PutPieces(new King(tab, Color.Black), new Position(0, 2));

                Screen.PrintBoard(tab);
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