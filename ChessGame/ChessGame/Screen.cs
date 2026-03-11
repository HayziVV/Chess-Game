using board;
using Chess;
namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write(board.Row - i + " ");
                for (int j = 0; j < board.Row; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(Board board, bool[,] PossiblePositions)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor AltBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write(board.Row - i + " ");
                for (int j = 0; j < board.Row; j++)
                {
                    if (PossiblePositions[i, j]) 
                        Console.BackgroundColor = AltBackground;
                    else 
                        Console.BackgroundColor = OriginalBackground;
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = OriginalBackground;
        }


        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}