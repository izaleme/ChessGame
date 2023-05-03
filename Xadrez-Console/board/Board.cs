namespace board
{
    class Board
    {
        #region  Attributes/Properties

        public int lines { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;

        #endregion

        #region  Builders

        public Board(int linhas, int colunas)
        {
            this.lines = linhas;
            this.columns = colunas;
            pieces = new Piece[linhas, colunas];
        }

        #endregion

        #region  Methods

        public Piece Piece(int linha, int coluna)
        {
            return pieces[linha, coluna];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidPosition(pos);
            return Piece(pos) != null;
        }

        public void PutPieces(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new BoardException("One piece already exists in that position!");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece aux = Piece(position);
            aux.position = null;
            pieces[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= lines || position.Column < 0 || position.Column >= columns)
            {
                return false;   // Return quebra o método
            }
            return true;
        }

        public void ValidPositionException(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }

        #endregion
    }
}