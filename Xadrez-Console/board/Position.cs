namespace board
{
    class Position
    {
        #region  Attributes/Properties

        public int Lines { get; set; }
        public int coluna { get; set; }

        #endregion

        #region  Builders

        public Position(int linha, int coluna)
        {
            this.Lines = linha;
            this.coluna = coluna;
        }

        #endregion

        #region  Methods

        public override string ToString()
        {
            return Lines
                + ", "
                + coluna;
        }

        #endregion
    }
}