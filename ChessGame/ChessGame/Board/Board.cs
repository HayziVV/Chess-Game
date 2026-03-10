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

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            
            return Pieces[position.Line, position.Column];
            
        }

        public void AddPiece(Piece p, Position position)
        {
            if (PieceExist(position))
            {
                throw new BoardException("Already exists a piece in this position!");
            }
            Pieces[position.Line, position.Column] = p;
            p.Position = position;
        }

        public bool PieceExist(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public bool ValidPosition(Position position)
        {
            bool valid = (position.Line<0 || position.Line >= Line || position.Column <0 || position.Column >= Column) ? false : true;
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
