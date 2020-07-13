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
            Square currentSquare = board.FindPiece(this);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j ++)
                {    
                    availableMoves.Add(Square.At(currentSquare.Row+i,currentSquare.Col+j));
                }
            }
            availableMoves.Remove(currentSquare);
            return availableMoves;
        }
    }
}