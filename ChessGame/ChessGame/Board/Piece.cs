namespace ChessGame.board
{
    internal class Piece
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
    }
}
