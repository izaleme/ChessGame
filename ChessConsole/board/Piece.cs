namespace board
{
    abstract class Piece
    {
        #region  Attributes/Properties

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Board Board { get; protected set; }

        #endregion

        #region  Builders

        public Piece(Board board, Color color) {
            Position = null;
            Board = board;
            Color = color;
            QtdMovimentos = 0;
        }

        #endregion

        #region  Methods

        public void AddQtdMove() {
            QtdMovimentos++;
        }

        public void RemoveQtdeMove() {
            QtdMovimentos--;
        }

        public bool ExistPossibleMoves() {
            bool[,] mat = PossibleMoves();

            for (int i = 0; i < Board.lines; i++) {
                for (int j = 0; j < Board.columns; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleMoves(Position pos) {
            return PossibleMoves()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMoves();

        #endregion
    }
}