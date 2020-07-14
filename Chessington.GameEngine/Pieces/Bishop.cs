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
            var moveGetter = new MoveGetter();
            Square currentSquare = board.FindPiece(this);
            var availableMoves = moveGetter.GetDiagonalMoves(currentSquare, board);
            availableMoves.RemoveAll(s=>(board.GetPiece(s)!=null && board.GetPiece(s).Player==this.Player));
            return availableMoves;
        }

        
    }
}