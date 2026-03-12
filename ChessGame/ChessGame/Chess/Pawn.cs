using board;
namespace Chess
{
    class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        private bool ExistEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p.Color != Color;
        }
        private bool Empty(Position position)
        {
            return Board.Piece(position) == null;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];
            Position position = new Position(0, 0);
            if (Color == Color.White)
            {
                position.SetValues(Position.Row - 1, Position.Column);
                if(Board.ValidPosition(position) && Empty(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(position) && Empty(position) && MovementCounts == 0)
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(position) && Empty(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(position) && Empty(position) && MovementCounts == 0)
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
                position.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P ";
        }
    }
}
