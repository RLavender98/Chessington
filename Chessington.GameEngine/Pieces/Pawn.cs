using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

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
            availableMoves.AddRange(GetPawnMoves(currentSquare, board));
            return availableMoves;
        }
        
        public List<Square> GetPawnMoves(Square currentSquare, Board board)
        {
            int drow = 0;
            List<Square> diagonals = new List<Square>();
            if (this.Player == Player.White)
                drow = -1;
            else if(this.Player == Player.Black)
                drow = 1;
            var pawnMoves = new List<Square>();
            TravelStep forwards = new TravelStep(0,drow);
            TravelStep forwardsTwo = new TravelStep(0, drow + drow);
            TravelStep forwardLeft = new TravelStep(-1, drow);
            TravelStep forwardRight = new TravelStep(1,drow);
            if (StepIsEmptyAndValid(forwards, currentSquare, board))
            {
                pawnMoves.Add(forwards.TravelFromSquare(currentSquare));
                if(!this.HasThisPieceEverMoved && StepIsEmptyAndValid(forwardsTwo, currentSquare, board))
                    pawnMoves.Add(forwardsTwo.TravelFromSquare(currentSquare));
                }
            if(StepLandsOnOpposingPieceAndIsValid(forwardLeft, currentSquare, board))
                pawnMoves.Add(forwardLeft.TravelFromSquare(currentSquare));
            if(StepLandsOnOpposingPieceAndIsValid(forwardRight,currentSquare,board))
                pawnMoves.Add(forwardRight.TravelFromSquare(currentSquare));
            return pawnMoves;
            
        }

        private bool StepIsEmptyAndValid(TravelStep direction, Square currentSquare, Board board)
        {
            if (direction.TravelFromSquare(currentSquare).IsOnTheBoard())
                return board.GetPiece(direction.TravelFromSquare(currentSquare)) == null;
            return false;
        }
        private bool StepLandsOnOpposingPieceAndIsValid(TravelStep direction, Square currentSquare, Board board)
        {
            if (direction.TravelFromSquare(currentSquare).IsOnTheBoard())
                return board.GetPiece(direction.TravelFromSquare(currentSquare)) != null &&
                       board.GetPiece(direction.TravelFromSquare(currentSquare)).Player != this.Player;
            return false;
        }
    }
}