using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            HasThisPieceEverMoved = false;
        }
        public bool HasThisPieceEverMoved { get; private set; }
        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            if (!HasThisPieceEverMoved)
            {
                HasThisPieceEverMoved = true;
            }
        }
    }
}