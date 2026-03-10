using ChessGame.board;
namespace ChessGame.Chess
{
    class Queen : Piece
    {

        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q ";
        }
    }
}
