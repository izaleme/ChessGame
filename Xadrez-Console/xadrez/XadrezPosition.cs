using board;

namespace xadrez
{
    class XadrezPosition
    {
        #region  Attributes/Properties

        public char Column { get; set; }
        public int Line { get; set; }

        #endregion

        #region  Builders

        public XadrezPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        #endregion

        #region  Methods

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'A');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }

        #endregion

    }
}
