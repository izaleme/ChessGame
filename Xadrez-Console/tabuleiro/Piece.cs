namespace tabuleiro
{
    class Piece
    {
        public Position position { get; set; }
        public Cor cor { get; protected set; }
        public int qntdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Piece(Position position, Tabuleiro tab, Cor cor)
        {
            this.position = position;
            this.tab = tab;
            this.cor = cor;
            this.qntdMovimentos = 0;
        }
    }
}