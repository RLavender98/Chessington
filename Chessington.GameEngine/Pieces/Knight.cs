using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var moveGetter = new MoveGetter();
            Square currentSquare = board.FindPiece(this);
            availableMoves.AddRange(moveGetter.GetKnightMoves(currentSquare));
            return availableMoves;
        }
    }
}