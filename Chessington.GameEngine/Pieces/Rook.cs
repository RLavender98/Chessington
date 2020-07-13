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
            Square currentSquare = board.FindPiece(this);
            for (int col = 0; col < 8; col++)
            {
                availableMoves.Add(Square.At(currentSquare.Row,col));
            }
            for (int row = 0; row < 8; row++)
            {
                availableMoves.Add(Square.At(row,currentSquare.Col));
            }

            availableMoves.Remove(currentSquare);
            return availableMoves;
        }
    }
}