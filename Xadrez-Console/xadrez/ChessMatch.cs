using System.Collections.Generic;
using board;

namespace xadrez
{
    class ChessMatch    // Partida de Xadrez
    {
        #region  Attributes/Properties

        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; set; }
        public bool finished { get; private set; }
        public bool check { get; private set; }
        public Piece vulnerableEnPassant { get; set; }

        private HashSet<Piece> pieces;
        private HashSet<Piece> taken;

        #endregion

        #region  Builders

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            vulnerableEnPassant = null;
            pieces = new HashSet<Piece>();
            taken = new HashSet<Piece>();
            PutPieces();
        }

        #endregion

        #region  Methods

        public Piece DoMovement(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.AddQtdMove();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
            if (capturedPiece != null)
                taken.Add(capturedPiece);

            // #jogadaespecial roque pequeno    // ARRUMAR
            if (p is King && destiny.Column == origin.Column + 2) {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = board.RemovePiece(originT);
                T.AddQtdMove();
                board.PutPiece(T, destinyT);
            }

            // #jogadaespecial roque grande     // ARRUMAR
            if (p is King && destiny.Column == origin.Column - 2) {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = board.RemovePiece(originT);
                T.AddQtdMove();
                board.PutPiece(T, destinyT);
            }

            // #jogadaespecial en passant       // ARRUMAR
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    else
                        posP = new Position(destiny.Line - 1, destiny.Column);

                    capturedPiece = board.RemovePiece(posP);
                    taken.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destiny);
            p.RemoveQtdeMove();
            if (capturedPiece != null)
            {
                board.PutPiece(capturedPiece, destiny);
                taken.Remove(capturedPiece);
            }
            board.PutPiece(p, origin);

            // #jogadaespecial roque pequeno
            if (p is King && destiny.Column == origin.Column + 2) {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = board.RemovePiece(destinyT);
                T.RemoveQtdeMove();
                board.PutPiece(T, originT);
            }

            // #jogadaespecial roque grande
            if (p is King && destiny.Column == origin.Column - 2) {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = board.RemovePiece(destinyT);
                T.RemoveQtdeMove();
                board.PutPiece(T, originT);
            }

            // #jogadaespecial en passant
            if (p is Pawn) {
                if (origin.Column != destiny.Column && capturedPiece == vulnerableEnPassant)
                {
                    Piece pawn = board.RemovePiece(destiny);
                    Position posP;
                    if (p.Color == Color.White) {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    board.PutPiece(pawn, posP);
                }
            }
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece capturedPiece = DoMovement(origin, destiny);

            if (IsOnCheck(currentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            Piece p = board.Piece(destiny);

            // #jogadaespecial promocao
            if (p is Pawn)
            {
                if ((p.Color == Color.White && destiny.Line == 0) || (p.Color == Color.Black && destiny.Line == 7))
                {
                    p = board.RemovePiece(destiny);
                    pieces.Remove(p);
                    Piece lady = new Lady(board, p.Color);
                    board.PutPiece(lady, destiny);
                    pieces.Add(lady);
                }
            }

            if (IsOnCheck(Adversary(currentPlayer)))
                check = true;
            else
                check = false;

            if (IsOnCheck(Adversary(currentPlayer))) {
                finished = true;
            } else {
                turn++;
                ChangePlayer();
            }

            // #jogadaespecial en passant
            if (p is Pawn && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
            {
                vulnerableEnPassant = p;
            } else
            {
                vulnerableEnPassant = null;
            }
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if (currentPlayer != board.Piece(pos).Color)
            {
                throw new BoardException("The original piece chosen is not yours!");
            }
            if (!board.Piece(pos).ExistPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen parent tile!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.Piece(origin).PossibleMoves(destiny))
            {
                throw new BoardException("Invalid target position!");
            }
        }

        private void ChangePlayer()
        {
            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in taken)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                    return x;
            }
            return null;
        }

        public bool IsOnCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }
            foreach (Piece x in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[K.Position.Line, K.Position.Column])
                    return true;
            }
            return false;
        }

        public bool TestCheckMate(Color color)
        {
            if (!IsOnCheck(color))
                return false;

            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i  < board.lines; i++) {
                    for (int j = 0; j < board.columns; j++) {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = DoMovement(origin, destiny);
                            bool testCheck = IsOnCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('A', 1, new Tower(board, Color.White));
            PutNewPiece('B', 1, new Horse(board, Color.White));
            PutNewPiece('C', 1, new Bishop(board, Color.White));
            PutNewPiece('D', 1, new Lady(board, Color.White));
            PutNewPiece('E', 1, new King(board, Color.White, this));
            PutNewPiece('F', 1, new Bishop(board, Color.White));
            PutNewPiece('G', 1, new Horse(board, Color.White));
            PutNewPiece('H', 1, new Tower(board, Color.White));
            PutNewPiece('A', 2, new Pawn(board, Color.White, this));
            PutNewPiece('B', 2, new Pawn(board, Color.White, this));
            PutNewPiece('C', 2, new Pawn(board, Color.White, this));
            PutNewPiece('D', 2, new Pawn(board, Color.White, this));
            PutNewPiece('E', 2, new Pawn(board, Color.White, this));
            PutNewPiece('F', 2, new Pawn(board, Color.White, this));
            PutNewPiece('G', 2, new Pawn(board, Color.White, this));
            PutNewPiece('H', 2, new Pawn(board, Color.White, this));

            PutNewPiece('A', 8, new Tower(board, Color.Black));
            PutNewPiece('B', 8, new Horse(board, Color.Black));
            PutNewPiece('C', 8, new Bishop(board, Color.Black));
            PutNewPiece('D', 8, new Lady(board, Color.Black));
            PutNewPiece('E', 8, new King(board, Color.Black, this));
            PutNewPiece('F', 8, new Bishop(board, Color.Black));
            PutNewPiece('G', 8, new Horse(board, Color.Black));
            PutNewPiece('H', 8, new Tower(board, Color.Black));
            PutNewPiece('A', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('B', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('C', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('D', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('E', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('F', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('G', 7, new Pawn(board, Color.Black, this));
            PutNewPiece('H', 7, new Pawn(board, Color.Black, this));
        }

        #endregion
    }
}
