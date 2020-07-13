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
            var availableMoves = new List<Square>();
            Square currentSquare = board.FindPiece(this);
            for (int i = Math.Max(0 - currentSquare.Row, 0 - currentSquare.Col);
                i < 8 - currentSquare.Col && i < 8 - currentSquare.Row;
                i++)
            {
                availableMoves.Add(Square.At(currentSquare.Row+i,currentSquare.Col+i));
            }
            for (int i = Math.Max(currentSquare.Row - 7, 0-currentSquare.Col); 
                i < 8 - currentSquare.Col && i < currentSquare.Row; 
                i++)
            {
                availableMoves.Add(Square.At(currentSquare.Row -i,currentSquare.Col +i));
            }

            availableMoves.RemoveAll(s=>s==currentSquare);
            return availableMoves;
        }
    }
}