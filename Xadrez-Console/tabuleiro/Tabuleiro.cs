namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Piece[,] pieces;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new Piece[linhas, colunas];
        }

        public Piece Piece (int linha, int coluna)
        {
            return pieces[linha, coluna];
        }
    }
}
