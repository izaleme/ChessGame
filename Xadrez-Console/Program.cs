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
            XadrezPosition position = new XadrezPosition('C', 7);

            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());

            Console.ReadLine();
        }

        #endregion
    }
}