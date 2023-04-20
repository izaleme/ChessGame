namespace board
{
    class Piece
    {
        #region  Attributes/Properties

        public Position position { get; set; }
        public Color cor { get; protected set; }
        public int qntdMovimentos { get; protected set; }
        public Board tab { get; protected set; }

        #endregion

        #region  Builders

        public Piece(Board tab, Color cor)
        {
            this.position = null;
            this.tab = tab;
            this.cor = cor;
            this.qntdMovimentos = 0;
        }

        #endregion

        #region  Methods

        #endregion
    }
}