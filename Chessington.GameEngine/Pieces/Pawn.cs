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
            var pawnMoves = new List<Square>();
            Square forwards = new Square();
            Square twoForwards = new Square();
            List<Square> diagonals = new List<Square>();
            if (this.Player == Player.White)
            {
                forwards = Square.At(currentSquare.Row - 1, currentSquare.Col);
                twoForwards = Square.At(currentSquare.Row - 2, currentSquare.Col);
                diagonals.Add(Square.At(currentSquare.Row - 1, currentSquare.Col-1));
                diagonals.Add(Square.At(currentSquare.Row - 1, currentSquare.Col+1));
            }
            else if(this.Player == Player.Black)
            {
                forwards = Square.At(currentSquare.Row + 1, currentSquare.Col);
                twoForwards = Square.At(currentSquare.Row + 2, currentSquare.Col);
                diagonals.Add(Square.At(currentSquare.Row + 1, currentSquare.Col-1));
                diagonals.Add(Square.At(currentSquare.Row + 1, currentSquare.Col+1));
            }

            if (forwards.IsOnTheBoard())
                if (board.GetPiece(forwards) == null)
                {
                    pawnMoves.Add(forwards);  
                    if (!HasThisPieceEverMoved && twoForwards.IsOnTheBoard()) 
                        if(board.GetPiece(twoForwards) == null)
                            pawnMoves.Add(twoForwards);
                }

            foreach (var diagonal in diagonals)
            {
                if(diagonal.IsOnTheBoard())
                    if(board.GetPiece(diagonal)!=null && board.GetPiece(diagonal).Player!=this.Player)
                        pawnMoves.Add(diagonal);
            }
            return pawnMoves;
            
        }
    }
}