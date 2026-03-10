namespace ChessGame.board
{
    internal class Board
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces;

        public Board(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[Row, Column];
        }

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            
            return Pieces[position.Row, position.Column];
            
        }

        public void AddPiece(Piece p, Position position)
        {
            if (PieceExist(position))
            {
                throw new BoardException("Already exists a piece in this position!");
            }
            Pieces[position.Row, position.Column] = p;
            p.Position = position;
        }

        public bool PieceExist(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            bool valid = (position.Row<0 || position.Row >= Row || position.Column <0 || position.Column >= Column) ? false : true;
            return valid; 
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
