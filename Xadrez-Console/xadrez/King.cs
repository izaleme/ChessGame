using board;

namespace xadrez
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        private bool TestTowerForRoque(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtdMovimentos == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[Board.lines, Board.columns];
            Position pos = new Position(0, 0);

            // O Rei tem 8 possíveis movimentos, que são as casas ao seu redor.

            // Above (acima)
            pos.SetValues(pos.Line - 1, pos.Column);
            if (Board.ValidPosition(pos) && CanMove(pos)){
                matriz[pos.Line, pos.Column] = true;
            }

            // North East (nordeste)
            pos.SetValues(pos.Line - 1, pos.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Right (direita)
            pos.SetValues(pos.Line, pos.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Southeast (sudeste)
            pos.SetValues(pos.Line + 1, pos.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Below (abaixo)
            pos.SetValues(pos.Line + 1, pos.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // South-West (sudoeste)
            pos.SetValues(pos.Line + 1, pos.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Left (esquerda)
            pos.SetValues(pos.Line, pos.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // Northwest (noroeste)
            pos.SetValues(pos.Line - 1, pos.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matriz[pos.Line, pos.Column] = true;
            }

            // #jogadaespecial roque
            if (QtdMovimentos == 0 && !match.check)
            {
                // #jogadaespecial roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (TestTowerForRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        matriz[Position.Line, Position.Column + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (TestTowerForRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        matriz[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
