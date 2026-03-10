namespace ChessGame.board
{
    internal class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private Piece[,] Piece;

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }
}
