using System;
using board;

namespace xadrez
{
    class ChessMatch
    {
        #region  Attributes/Properties

        private int turno;
        private Color jogadorAtual;
        public Board board { get; private set; }
        public bool finished { get; private set; }

        #endregion

        #region  Builders

        public ChessMatch()
        {
            board = new Board(8, 8);
            turno = 1;
            jogadorAtual = Color.White;
            finished = false;
            PutPieces();
        }

        #endregion

        #region  Methods

        public void DoMovement(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.addQtdMove();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPieces(p, destiny);
        }

        private void PutPieces()
        {
            board.PutPieces(new King(board, Color.White), new ChessPosition('D', 1).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('C', 1).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('C', 2).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('D', 2).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('E', 1).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('E', 2).ToPosition());

            board.PutPieces(new King(board, Color.White), new ChessPosition('D', 8).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('C', 7).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('C', 8).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('D', 7).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('E', 7).ToPosition());
            board.PutPieces(new Tower(board, Color.White), new ChessPosition('E', 8).ToPosition());
        }

        #endregion

    }
}
