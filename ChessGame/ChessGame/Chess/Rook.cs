using board;
namespace Chess
{
    class Rook : Piece
    {

        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position position = new Position(0, 0);
            int i = 1;
            bool rookCanContinue = true;

            position.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if(Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row -= 1;
            }

            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row += 1;
            }

            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column -= 1;
            }

            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column += 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R ";
        }
    }
}
