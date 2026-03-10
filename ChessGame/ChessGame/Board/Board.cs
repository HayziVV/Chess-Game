namespace ChessGame.board
{
    internal class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces;

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
            Pieces = new Piece[Line, Column];
        }

        public Piece piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public void addPiece(Piece p, Position position)
        {
            Pieces[position.Line, position.Column] = p;
            p.Position = position;
        }
    }
}
