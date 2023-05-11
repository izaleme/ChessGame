using board;

namespace xadrez
{
    class Bishop : Piece    // BISHOP = BISPO
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.lines, Board.columns];

            Position pos = new Position(0, 0);

            // Northwest (noroeste)
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[Position.Line, Position.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(Position.Line - 1, Position.Column - 1);
            }

            // North East (nordeste)
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[Position.Line, Position.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(Position.Line - 1, Position.Column + 1);
            }

            // Southeast (sudeste)
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[Position.Line, Position.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
            }

            // South-West (sudoeste)
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[Position.Line, Position.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
            }

            return mat;
        }
    }
}
