﻿using board;

namespace xadrez
{
    class Pawn : Piece
    {
        private ChessMatch match;

        public Pawn(Board board, Color color, ChessMatch match) : base (board, color) {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private  bool ExistEnemy(Position pos) {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.lines, Board.columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && QtdMovimentos == 0) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Piece(left) == match.vulnerableEnPassant) {
                        mat[left.Line - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.Piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.Piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
