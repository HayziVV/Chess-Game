using ChessGame.board;
namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write((board.Row - i) + " ");
                for (int j = 0; j < board.Row; j++)
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