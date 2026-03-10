using ChessGame.board;
namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                for (int j = 0; j < board.Line; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write($"{board.Piece(i, j)} ");
                }
            Console.WriteLine();
            }
        }
    }
}