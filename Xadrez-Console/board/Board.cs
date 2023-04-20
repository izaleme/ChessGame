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

        public void PutPieces(Piece p, Position pos)
        {
            pieces[pos.Lines, pos.coluna] = p;
            p.position = pos;
        }

        #endregion
    }
}