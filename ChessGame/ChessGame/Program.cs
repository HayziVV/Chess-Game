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
                ChessPosition position = new ChessPosition('c', 7);
                Console.WriteLine(position);
                Console.WriteLine(position.toPosition());
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
