using board;
using Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().toPosition();
                    bool[,] PossiblePositions = match.Board.Piece(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, PossiblePositions);
                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position Destination = Screen.ReadChessPosition().toPosition();

                    match.PerformMovement(origin, Destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
