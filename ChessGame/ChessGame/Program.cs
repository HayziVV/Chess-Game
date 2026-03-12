using board;
using Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {

                    ChessMatch match = new ChessMatch();
                    while (!match.Finished)
                    {
                        try
                        {
                            Console.Clear();
                            Screen.PrintMatch(match);
                            Console.WriteLine();
                            Console.Write("Origin: ");
                            Position origin = Screen.ReadChessPosition().toPosition();
                            match.ValidateOriginPosition(origin);

                            bool[,] PossiblePositions = match.Board.Piece(origin).PossibleMoviments();

                            Console.Clear();
                            Screen.PrintBoard(match.Board, PossiblePositions);

                            Console.WriteLine();
                            Console.Write("Destination: ");
                            Position destination = Screen.ReadChessPosition().toPosition();
                            match.ValidateDestinationPosition(origin, destination);

                            match.MakeMove(origin, destination);
                        }
                        catch (BoardException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Write("Press enter key to continue...");
                            Console.ReadLine();
                        }
                    }
                    Console.Clear();
                    Screen.PrintMatch(match);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
