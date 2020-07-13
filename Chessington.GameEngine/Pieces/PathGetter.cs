using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Path
    {
        public List<Square> PathSteps { get; set; }
        
        public Path(Square from, Square to)
        {
            var path =new List<Square>();
            int colDif = to.Col - from.Col;
            int rowDif = to.Row - from.Row;
            if (colDif == 0)
            {
                if (rowDif > 0)
                    for (int i = 1; i <= rowDif; i++)
                    {
                        path.Add(Square.At(from.Row + i, from.Col));
                    }
                else
                    for (int i = 1; i <= 0 - rowDif; i++)
                    {
                        path.Add(Square.At(from.Row - i, from.Col));
                    }
            }
            else if (rowDif == 0)
            {
                if (colDif > 0)
                    for (int i = 1; i <= colDif; i++)
                    {
                        path.Add(Square.At(from.Row, from.Col + i));
                    }
                else
                    for (int i = 1; i <= 0 - colDif; i++)
                    {
                        path.Add(Square.At(from.Row, from.Col - i));
                    }
            }
            else if (rowDif == colDif)
            {
                if(rowDif>0)
                    for (int i = 1; i <= rowDif; i++)
                    {
                        path.Add(Square.At(from.Row+i,from.Col+i));
                    }
                else
                    for (int i = 1; i <= 0-rowDif; i++)
                    {
                        path.Add(Square.At(from.Row-i,from.Col-i));
                    }
            }
            else if (rowDif == 0-colDif)
            {
                if(rowDif>0)
                    for (int i = 1; i <= rowDif; i++)
                    {
                        path.Add(Square.At(from.Row+i,from.Col-i));
                    }
                else
                    for (int i = 1; i <= 0-rowDif; i++)
                    {
                        path.Add(Square.At(from.Row-i,from.Col+i));
                    }
            }

            PathSteps= path;
        }

        public bool IsPathEmpty(Board board)
        {
            int count = 0;
            foreach (Square square in PathSteps)
            {
                if (board.GetPiece(square) != null)
                    count += 1;
            }

            return count == 0;
        }
    }
}