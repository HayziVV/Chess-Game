using ChessGame.board;
using ChessGame.Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.addPiece(new Rook(board, Color.Black), new Position (0,0));
            board.addPiece(new Rook(board, Color.Black), new Position (1,3));
            board.addPiece(new King(board, Color.Black), new Position (2,4));
            Screen.PrintBoard(board);
        }
    }
}
