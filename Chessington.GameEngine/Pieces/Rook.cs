using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var moveGetter = new MoveGetter();
            Square currentSquare = board.FindPiece(this);
            availableMoves.AddRange(moveGetter.GetLateralMoves(currentSquare));
            availableMoves = availableMoves.FindAll(s => new Path(currentSquare, s).IsPathEmpty(board));
            availableMoves.RemoveAll(s=>(board.GetPiece(s)!=null && board.GetPiece(s).Player==this.Player));
            return availableMoves;
        }

        
    }
}