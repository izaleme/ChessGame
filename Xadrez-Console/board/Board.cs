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

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        #endregion

        #region  Methods

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidPositionException(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new BoardException("One piece already exists in that position!");
            }
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece aux = Piece(position);
            aux.Position = null;
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