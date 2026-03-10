using ChessGame.board;
namespace ChessGame.Chess
{
    class Rook : Piece
    {

        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
