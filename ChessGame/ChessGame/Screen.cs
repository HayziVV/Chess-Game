using board;
using Chess;
using System.Collections.Generic;
namespace ChessGame
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {

            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (!match.Finished)
            {
                Console.WriteLine("Awaiting play from: " + match.CurrentPlayer);
                if (match.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine($"WINNER: {match.CurrentPlayer}");
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> Set)
        {
            Console.Write("[");
            foreach (Piece piece in Set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
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
            string s = Console.ReadLine().ToLower();
            char column;
            int row;
            if (s.Length == 2)
            {
                column = s[0];
                row = s[1] - '0';
                if ((row >= 1 && row <= 8) && (column >= 'a' && column <= 'h'))
                {
                    return new ChessPosition(column, row);
                }
            }
            throw new BoardException("Invalid Position!");
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