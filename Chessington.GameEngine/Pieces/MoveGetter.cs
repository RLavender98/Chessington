using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class MoveGetter
    {
        public List<Square> GetLateralMoves(Square currentSquare, Board board)
        {
            var lateralMoves = new List<Square>();
            int col = currentSquare.Col+1;
            int encounter = 0;
            while (col < 8 && encounter == 0)
            {
                lateralMoves.Add(Square.At(currentSquare.Row, col));
                if (board.GetPiece(Square.At(currentSquare.Row, col)) == null)
                    col++;
                else
                    encounter++;
            }
            col = currentSquare.Col-1;
            encounter = 0;
            while(col>=0 && encounter==0)
            {
                lateralMoves.Add(Square.At(currentSquare.Row, col));
                if (board.GetPiece(Square.At(currentSquare.Row, col)) == null)
                    col--;
                else
                    encounter++;
            }
            int row = currentSquare.Row+1;
            encounter = 0;
            while(row<8 && encounter==0)
            {
                lateralMoves.Add(Square.At(row, currentSquare.Col));
                if (board.GetPiece(Square.At(row, currentSquare.Col)) == null)
                    row++;
                else
                    encounter++;
            }
            encounter = 0;
            row = currentSquare.Row-1;
            while(row>=0 && encounter==0)
            {
                lateralMoves.Add(Square.At(row, currentSquare.Col));
                if (board.GetPiece(Square.At(row, currentSquare.Col)) == null)
                    row--;
                else
                    encounter++;
            }
            return lateralMoves;
        }
        
        public List<Square> GetDiagonalMoves(Square currentSquare,Board board)
        {
            var diagonalMoves = new List<Square>();
            int i = -1;
            int encounter = 0;
            while (i >= Math.Max(0 - currentSquare.Row, 0 - currentSquare.Col)&& encounter==0)
            {
                diagonalMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + i));
                if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col + i))==null)
                    i--;
                else
                    encounter++;
            }
            i = 1;
            encounter = 0;
            while(i < 8 - currentSquare.Col && i < 8 - currentSquare.Row && encounter==0)
            {
                diagonalMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + i));
                if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col + i)) == null)
                    i++;
                else
                    encounter++;
            }

            i = -1;
            encounter = 0;
            while (i >= Math.Max(currentSquare.Row - 7, 0-currentSquare.Col)&& encounter ==0)
            {
                diagonalMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col + i)) == null) 
                    i--;
                else
                    encounter++;
            }
            i = 1;
            encounter = 0;
            while (i < 8 - currentSquare.Col && i < currentSquare.Row && encounter == 0)
            {
                diagonalMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col + i)) == null)
                    i++;
                else
                    encounter++;
            }
            diagonalMoves.RemoveAll(s=>s==currentSquare);
            return diagonalMoves;
        }
    }
}