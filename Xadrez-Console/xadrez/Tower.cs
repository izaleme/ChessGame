using board;

namespace xadrez
{
    class Tower : Piece
    {
        public Tower(Board tab, Color cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.lines, Board.columns];
            Position pos = new Position(0, 0);

            // A Torre tem 4 possíveis movimentos

            // Above (acima)
            pos.SetValues(pos.Line - 1, pos.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)    // Se chegar ao fim do tabuleiro ou bater em outra peça, para
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // Below (abaixo)
            pos.SetValues(pos.Line + 1, pos.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)    // Se chegar ao fim do tabuleiro ou bater em outra peça, para
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // Right (direita)
            pos.SetValues(pos.Line, pos.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)    // Se chegar ao fim do tabuleiro ou bater em outra peça, para
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // Left (esquerda)
            pos.SetValues(pos.Line, pos.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)    // Se chegar ao fim do tabuleiro ou bater em outra peça, para
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return matriz;
        }
    }
}
