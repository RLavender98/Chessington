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
            Square currentSquare = board.FindPiece(this);
            availableMoves.AddRange(GetKnightMoves(currentSquare));
            availableMoves.RemoveAll(s => !s.IsOnTheBoard());
            availableMoves.RemoveAll(s=>(board.GetPiece(s)!=null && board.GetPiece(s).Player==this.Player));
            return availableMoves;
        }
        
        public List<Square> GetKnightMoves(Square currentSquare)
        {
            var availableMoves = new List<Square>();
            foreach (int i in new[] {-2, 2})
            {
                foreach (int j in new[] {-1, 1})
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + j));
                    availableMoves.Add(Square.At(currentSquare.Row + j, currentSquare.Col + i));
                }
            }

            return availableMoves;
        }
    }
}