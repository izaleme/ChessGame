namespace board
{
    class Position
    {
        #region  Attributes/Properties

        public int Line { get; set; }
        public int Column { get; set; }

        #endregion

        #region  Builders

        public Position(int linha, int coluna)
        {
            Line = linha;
            Column = coluna;
        }

        #endregion

        #region  Methods

        public override string ToString()
        {
            return Line
                + ", "
                + Column;
        }

        #endregion
    }
}