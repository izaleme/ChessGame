using System;
using board;
using xadrez;

namespace xadrez_console
{
    class Screen
    {
        #region  Methods

        public static void PrintBoard(Board tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.columns; j++)
                {
                    if (tab.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(tab.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine().ToUpper();    // Coloca a letra sempre em maiúsculo para não dar Out Of Range Exception
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.cor == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

        #endregion
    }
}
