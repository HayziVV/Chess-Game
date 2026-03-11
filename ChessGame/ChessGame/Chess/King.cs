using board;
namespace Chess
{
    class King : Piece
    {

        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K ";
        }
        

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position position = new Position(0, 0);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    position.SetValues(Position.Row + i, Position.Column + j);
                    if (Board.ValidPosition(position) && CanMove(position))
                    {
                        mat[position.Row, position.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
