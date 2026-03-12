namespace board
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementCounts { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementCounts = 0;
        }

        public void IncreaseMovementCount()
        {
            MovementCounts++;
        }

        protected bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public bool ExistPossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();
            for(int i=0; i < Board.Row; i++)
            {
                for(int j=0; j<Board.Column; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveTo(Position destination)
        {
            return PossibleMoviments()[destination.Row, destination.Column];
        }

        public abstract bool[,] PossibleMoviments();

        
    }
}
