using board;

namespace xadrez
{
    class King : Piece
    {
        public King(Board tab, Color cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
