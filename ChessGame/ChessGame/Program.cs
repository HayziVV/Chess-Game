using ChessGame.board;
using ChessGame.Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);
                board.AddPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.AddPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.AddPiece(new King(board, Color.Black), new Position(0, 2));

                board.AddPiece(new Rook(board, Color.White), new Position(0, 4));
                board.AddPiece(new Rook(board, Color.White), new Position(0, 5));
                board.AddPiece(new King(board, Color.White), new Position(0, 1));

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
