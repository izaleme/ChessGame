using System;
using board;

namespace Xadrez_Console
{
    class Screen
    {
        #region  Attributes/Properties

        #endregion

        #region  Builders

        #endregion

        #region  Methods

        public static void PrintBoard(Board tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                for (int j = 0; j < tab.columns; j++)
                {
                    if (tab.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}
