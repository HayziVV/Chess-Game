using board;
namespace Chess
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
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position position = new Position(0, 0);
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (MovementCounts == 0 && CanMove(position))
                {
                    mat[position.Row + 1, position.Column] = true;
                }
            }
            return mat;
        }
    }
}
