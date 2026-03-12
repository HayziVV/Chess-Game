using board;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; set; }
        public Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; } = false;
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }
        public Piece? VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPieces();
        }

        public Piece PerformMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovementCount();
            Piece CapturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(p, destination);
            if (CapturedPiece != null)
            {
                Captured.Add(CapturedPiece);
            }

            //Kingside Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position destinationRook = new Position(origin.Row, origin.Column + 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncreaseMovementCount();
                Board.AddPiece(R, destinationRook);
            }
            //Queenside Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position destinationRook = new Position(origin.Row, origin.Column - 1);
                Piece R = Board.RemovePiece(originRook);
                R.IncreaseMovementCount();
                Board.AddPiece(R, destinationRook);
            }

            //EnPassant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && CapturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destination.Row + 1, destination.Column);
                    }
                    else
                    {
                        posP = new Position(destination.Row - 1, destination.Column);
                    }
                    CapturedPiece = Board.RemovePiece(posP);
                    Captured.Add(CapturedPiece);
                }
            }
            return CapturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destination);
            p.DecreaseMovementCount();
            if (capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }
            Board.AddPiece(p, origin);
            //Kingside Castling
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position originRook = new Position(origin.Row, origin.Column + 3);
                Position destinationRook = new Position(origin.Row, origin.Column + 1);
                Piece R = Board.RemovePiece(destinationRook);
                R.DecreaseMovementCount();
                Board.AddPiece(R, originRook);
            }
            //Queenside Castling
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originRook = new Position(origin.Row, origin.Column - 4);
                Position destinationRook = new Position(origin.Row, origin.Column - 1);
                Piece R = Board.RemovePiece(destinationRook);
                R.DecreaseMovementCount();
                Board.AddPiece(R, originRook);
            }
            //EnPassant
            if (p is Pawn)
            {
                if (origin.Column != destination.Column && capturedPiece == VulnerableEnPassant)
                {
                    Piece piece = Board.RemovePiece(destination);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destination.Column);
                    }
                    else
                    {
                        posP = new Position(4, destination.Column);
                    }
                    Board.AddPiece(piece, posP);
                }
            }

        }

        public void MakeMove(Position origin, Position destination)
        {

            Piece capturedPiece = PerformMovement(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself into check");
            }

            Piece p = Board.Piece(destination);
            //Pawn Promotion
            if (p is Pawn)
            {
                if ((p.Color == Color.White && destination.Row == 0) || (p.Color == Color.Black && destination.Row == 7))
                {
                    p = Board.RemovePiece(destination);
                    Pieces.Remove(p);
                    Piece queen = new Queen(Board, p.Color);
                    Board.AddPiece(queen, destination);
                    Pieces.Add(queen);
                }
            }

            if (IsInCheck(Enemy(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsCheckmate(Enemy(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            //EnPassant
            if (p is Pawn && (destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2))
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }

        }


        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null)
            {
                throw new BoardException("There's no piece in the origin position");
            }
            if (CurrentPlayer != Board.Piece(origin).Color)
            {
                throw new BoardException($"The chosen piece doesn't belong to you!");
            }
            if (!Board.Piece(origin).ExistPossibleMoviments())
            {
                throw new BoardException($"There's no avaliable moviments for the chosen piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException($"Invalid destination!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        private Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece? King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color) ?? throw new BoardException($"There's no king from color: {color}");
            foreach (Piece x in PiecesInGame(Enemy(color)))
            {
                bool[,] mat = x.PossibleMoviments();
                if (mat[K.Position.Row, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMoviments();
                for (int i = 0; i < Board.Row; i++)
                {
                    for (int j = 0; j < Board.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = PerformMovement(origin, destination);
                            bool testCheck = IsInCheck(color);
                            UndoMovement(origin, destination, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }


        public void AddNewPieces(char column, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }

        private void AddPieces()
        {
            // White Pieces
            AddNewPieces('a', 1, new Rook(Board, Color.White));
            AddNewPieces('b', 1, new Knight(Board, Color.White));
            AddNewPieces('c', 1, new Bishop(Board, Color.White));
            AddNewPieces('d', 1, new Queen(Board, Color.White));
            AddNewPieces('e', 1, new King(Board, Color.White, this));
            AddNewPieces('f', 1, new Bishop(Board, Color.White));
            AddNewPieces('g', 1, new Knight(Board, Color.White));
            AddNewPieces('h', 1, new Rook(Board, Color.White));
            AddNewPieces('a', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('b', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('c', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('d', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('e', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('f', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('g', 2, new Pawn(Board, Color.White, this));
            AddNewPieces('h', 2, new Pawn(Board, Color.White, this));
            // Black Pieces
            AddNewPieces('a', 8, new Rook(Board, Color.Black));
            AddNewPieces('b', 8, new Knight(Board, Color.Black));
            AddNewPieces('c', 8, new Bishop(Board, Color.Black));
            AddNewPieces('d', 8, new Queen(Board, Color.Black));
            AddNewPieces('e', 8, new King(Board, Color.Black, this));
            AddNewPieces('f', 8, new Bishop(Board, Color.Black));
            AddNewPieces('g', 8, new Knight(Board, Color.Black));
            AddNewPieces('h', 8, new Rook(Board, Color.Black));
            AddNewPieces('a', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('b', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('c', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('d', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('e', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('f', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('g', 7, new Pawn(Board, Color.Black, this));
            AddNewPieces('h', 7, new Pawn(Board, Color.Black, this));

        }
    }
}
