using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            var moveGetter = new MoveGetter();
            availableMoves.AddRange(moveGetter.GetLateralMoves(currentSquare));
            availableMoves.AddRange(moveGetter.GetDiagonalMoves(currentSquare));
            availableMoves = availableMoves.FindAll(s => new Path(currentSquare, s).IsPathEmpty(board));
            return availableMoves;
        }
    }
}