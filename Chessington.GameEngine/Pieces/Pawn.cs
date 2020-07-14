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
            if(DiagonalStepLandsOnOpposingPieceAndIsValid(forwardLeft, currentSquare, board))
                pawnMoves.Add(forwardLeft.TravelFromSquare(currentSquare));
            if(DiagonalStepLandsOnOpposingPieceAndIsValid(forwardRight,currentSquare,board))
                pawnMoves.Add(forwardRight.TravelFromSquare(currentSquare));
            if(DiagonalStepIsValidEnPassantMove(forwardLeft, currentSquare,board,drow))
                pawnMoves.Add(forwardLeft.TravelFromSquare(currentSquare));
            if(DiagonalStepIsValidEnPassantMove(forwardRight, currentSquare,board,drow))
                pawnMoves.Add(forwardRight.TravelFromSquare(currentSquare));
            return pawnMoves;
            
        }

        private bool StepIsEmptyAndValid(TravelStep direction, Square currentSquare, Board board)
        {
            if (direction.TravelFromSquare(currentSquare).IsOnTheBoard())
                return board.GetPiece(direction.TravelFromSquare(currentSquare)) == null;
            return false;
        }
        private bool DiagonalStepLandsOnOpposingPieceAndIsValid(TravelStep direction, Square currentSquare, Board board)
        {
            if (direction.TravelFromSquare(currentSquare).IsOnTheBoard())
                return board.GetPiece(direction.TravelFromSquare(currentSquare)) != null &&
                       board.GetPiece(direction.TravelFromSquare(currentSquare)).Player != this.Player;
            return false;
        }

        private bool DiagonalStepIsValidEnPassantMove(TravelStep direction, Square currentSquare, Board board, int drow)
        {
            if (direction.TravelFromSquare(currentSquare).IsOnTheBoard())
                if (board.GetPiece(direction.TravelFromSquare(currentSquare)) == null)
                {
                    TravelStep sideways = new TravelStep(direction.DeltaCol,0);
                    if (board.GetPiece(sideways.TravelFromSquare(currentSquare))?.GetType() == typeof(Pawn)
                        &&board.GetPiece(sideways.TravelFromSquare(currentSquare))?.Player != this.Player)
                    {
                        TravelStep originOfOpposingPawn = new TravelStep(direction.DeltaCol, 2*direction.DeltaRow);
                        if (board.PreviousMove.From == originOfOpposingPawn.TravelFromSquare(currentSquare) 
                            && board.PreviousMove.To ==sideways.TravelFromSquare(currentSquare))
                            return true;
                    }
                }
            return false;
        }
    }
}