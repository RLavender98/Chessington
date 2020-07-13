using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                Square forwards = Square.At(currentSquare.Row - 1, currentSquare.Col);
                if (board.GetPiece(forwards) == null)
                {
                    availableMoves.Add(forwards);
                }
            }
            else if(this.Player == Player.Black)
            {
                Square forwards = Square.At(currentSquare.Row + 1, currentSquare.Col);
                if (board.GetPiece(forwards) == null)
                {
                    availableMoves.Add(forwards);
                }
            }
            return availableMoves;
        }
    }
}