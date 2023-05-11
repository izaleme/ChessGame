namespace board
{
    class Position
    {
        #region  Attributes/Properties

        public int Line { get; set; }
        public int Column { get; set; }

        #endregion

        #region  Builders

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        #endregion

        #region  Methods

        public void SetValues(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line
                + ", "
                + Column;
        }

        #endregion
    }
}