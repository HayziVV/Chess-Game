using board;
using System.Reflection.PortableExecutable;
namespace Chess
{
    internal class ChessMatch
    {
        public Board Board {get; private set;}
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            AddPieces();
            Finished = false;
        }
        public void PerformMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovementCount();
            Piece CapturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(p, destination);
        }
        private void AddPieces()
        {
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('c',1).toPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('c',2).toPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('d',2).toPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('e',2).toPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('e',1).toPosition());
            Board.AddPiece(new King(Board, Color.White), new ChessPosition('d',1).toPosition());
            
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('c',7).toPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('c',8).toPosition());
            Board.AddPiece(new King(Board, Color.Black), new ChessPosition('d',8).toPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('e',8).toPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('e',7).toPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('d',7).toPosition());
        }
    }
}
