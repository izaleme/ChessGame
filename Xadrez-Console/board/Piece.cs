namespace board
{
    class Piece
    {
        #region  Attributes/Properties

        public Position position { get; set; }
        public Color cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Board tab { get; protected set; }

        #endregion

        #region  Builders

        public Piece(Board tab, Color cor)
        {
            this.position = null;
            this.tab = tab;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        #endregion

        #region  Methods

        public void addQtdMove()
        {
            qtdMovimentos++;
        }

        #endregion
    }
}