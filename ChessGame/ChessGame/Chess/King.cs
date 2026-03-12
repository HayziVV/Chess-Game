using board;
namespace Chess
{
    class King : Piece
    {
        private ChessMatch Match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "K ";
        }

        private bool RookTestForCastling(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p is Rook && p.Color == Color && p.MovementCounts == 0;
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
            //Kingside Castling
            if (MovementCounts == 0 && !Match.Check)
            {
                Position positionRook1 = new Position(Position.Row, Position.Column + 3);
                if (RookTestForCastling(positionRook1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }
                //Queenside Castling
                Position positionRook2 = new Position(Position.Row, Position.Column - 4);
                if (RookTestForCastling(positionRook2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
