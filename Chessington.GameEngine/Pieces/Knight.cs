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
            for (int i = -2; i < 3; i+=4)
            {
                for (int j = -1; j < 2; j += 2)
                {    
                    availableMoves.Add(Square.At(currentSquare.Row+i,currentSquare.Col+j));
                    availableMoves.Add(Square.At(currentSquare.Row+j,currentSquare.Col+i));
                }
            }

            return availableMoves;
        }
    }
}