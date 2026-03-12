using board;
namespace Chess
{
    class Knight : Piece
    {

        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            int[] dRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] dColumn = { -1, 1, -2, 2, -2, 2, -1, 1 };
            Position position = new Position(0, 0);
            for (int i = 0; i < 8; i++)
            {
                position.SetValues(Position.Row + dRow[i], Position.Column + dColumn[i]);
                    if (Board.ValidPosition(position) && CanMove(position))
                    {
                        mat[position.Row, position.Column] = true;
                    }
            }
            return mat;
        }

        public override string ToString()
        {
            return "N ";
        }
    }
}
