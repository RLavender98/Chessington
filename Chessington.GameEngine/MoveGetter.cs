using System;
using System.Collections.Generic;
using System.Net;

namespace Chessington.GameEngine.Pieces
{
    public class MoveGetter
    {
        private List<Square> MovesInDirection(Square startingSquare, TravelStep direction, Board board)
        {
            List<Square> moves = new List<Square>();
            bool encounter = false;
            Square tempSquare = direction.TravelFromSquare(startingSquare);
            for (var steps = 0; tempSquare.IsOnTheBoard() && !encounter; steps++)
            {
                moves.Add(tempSquare);
                if (board.GetPiece(tempSquare) == null)
                    tempSquare = direction.TravelFromSquare(tempSquare);
                else
                    encounter = true;
            }

            return moves;
        }
        public List<Square> GetLateralMoves(Square currentSquare, Board board)
        {
            var lateralMoves = new List<Square>();
            TravelStep up = new TravelStep(0,-1);
            TravelStep down = new TravelStep(0,1);
            TravelStep left = new TravelStep(-1,0);
            TravelStep right = new TravelStep(1,0);
            lateralMoves.AddRange(MovesInDirection(currentSquare, up, board));
            lateralMoves.AddRange(MovesInDirection(currentSquare, down, board));
            lateralMoves.AddRange(MovesInDirection(currentSquare, left, board));
            lateralMoves.AddRange(MovesInDirection(currentSquare, right, board));
            return lateralMoves;
        }
        
        public List<Square> GetDiagonalMoves(Square currentSquare,Board board)
        {
            var diagonalMoves = new List<Square>();
            TravelStep upRight = new TravelStep(1,-1);
            TravelStep downRight = new TravelStep(1,1);
            TravelStep downLeft = new TravelStep(-1,1);
            TravelStep upLeft = new TravelStep(-1,-1);
            diagonalMoves.AddRange(MovesInDirection(currentSquare, upRight, board));
            diagonalMoves.AddRange(MovesInDirection(currentSquare, downRight, board));
            diagonalMoves.AddRange(MovesInDirection(currentSquare, downLeft, board));
            diagonalMoves.AddRange(MovesInDirection(currentSquare, upLeft, board));
            return diagonalMoves;
        }
    }
}