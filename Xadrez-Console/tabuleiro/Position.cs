namespace tabuleiro
{
    class Position
    {
        #region  Attributes/Properties

        public int linha { get; set; }
        public int coluna { get; set; }

        #endregion

        #region  Builders

        public Position(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        #endregion

        #region  Methods

        public override string ToString()
        {
            return linha
                + ", "
                + coluna;
        }

        #endregion

        #region  Events

        #endregion
    }
}