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
            availableMoves.AddRange(GetPawnMoves(currentSquare));
            availableMoves.RemoveAll(s => !s.IsOnTheBoard());
            availableMoves = availableMoves.FindAll(s=>new Path(currentSquare,s).IsPathEmpty(board));
            availableMoves.RemoveAll(s => board.GetPiece(s) != null);
            return availableMoves;
        }
        
        public List<Square> GetPawnMoves(Square currentSquare)
        {    
            var pawnMoves = new List<Square>();
            Square forwards = new Square();
            Square twoForwards = new Square();
            if (this.Player == Player.White)
            {
                forwards = Square.At(currentSquare.Row - 1, currentSquare.Col);
                twoForwards = Square.At(currentSquare.Row - 2, currentSquare.Col);
            }
            else if(this.Player == Player.Black)
            {
                forwards = Square.At(currentSquare.Row + 1, currentSquare.Col);
                twoForwards = Square.At(currentSquare.Row + 2, currentSquare.Col);
            }
            pawnMoves.Add(forwards);
            if (!HasThisPieceEverMoved) 
                pawnMoves.Add(twoForwards);
            return pawnMoves;
        }
    }
}