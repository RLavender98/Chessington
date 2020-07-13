using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class MoveGetter
    {
        public List<Square> GetLateralMoves(Square currentSquare)
        {
            var lateralMoves = new List<Square>();
            for (int col = 0; col < 8; col++)
            {
                lateralMoves.Add(Square.At(currentSquare.Row,col));
            }
            for (int row = 0; row < 8; row++)
            {
                lateralMoves.Add(Square.At(row,currentSquare.Col));
            }

            lateralMoves.RemoveAll(s=>s==currentSquare);
            return lateralMoves;
        }
        
        public List<Square> GetDiagonalMoves(Square currentSquare)
        {
            var availableMoves = new List<Square>();
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

        public List<Square> GetKingMoves(Square currentSquare)
        {
            var availableMoves = new List<Square>();
            foreach (int i in new[] {-1, 0, 1})
            {
                foreach (int j in new[] {-1, 0, 1})
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + j));
                }
            }

            availableMoves.Remove(currentSquare);
            return availableMoves;
        }
    }
}