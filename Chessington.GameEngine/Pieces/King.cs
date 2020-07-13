using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var moveGetter = new MoveGetter();
            Square currentSquare = board.FindPiece(this);
            availableMoves.AddRange(moveGetter.GetKingMoves(currentSquare));
            availableMoves.RemoveAll(s => !s.IsOnTheBoard());
            return availableMoves;
        }
    }
}