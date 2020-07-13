using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var moveGetter = new MoveGetter();
            Square currentSquare = board.FindPiece(this);
            availableMoves.AddRange(moveGetter.GetDiagonalMoves(currentSquare));
            availableMoves = availableMoves.FindAll(s => new Path(currentSquare, s).IsPathEmpty(board));
            return availableMoves;
        }

        
    }
}