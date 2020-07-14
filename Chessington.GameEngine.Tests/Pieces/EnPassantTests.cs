using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class EnPassantTests
    {
        [Test]
        public void WhitePawns_CanTakeOpposingPiecesEnPassant()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 0), whitePawn);
            board.AddPiece(Square.At(2, 1), blackPawn);
            
            blackPawn.MoveTo(board, Square.At(4, 1));
            var moves = whitePawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 1));
        }
        
        
        [Test]
        public void BlackPawns_CanTakeOpposingPiecesEnPassant()
        {
            var board = new Board();
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(7, 0), whitePawn);
            board.AddPiece(Square.At(5, 1), blackPawn);
            whitePawn.MoveTo(board, Square.At(5, 0));
            var moves = blackPawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 1));
        }
        
        [Test]
        public void WhitePawns_CanNotTakeEnPassantIfItWasntASingleMove()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var extraPawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 0), whitePawn);
            board.AddPiece(Square.At(2, 1), blackPawn);
            board.AddPiece(Square.At(7, 6), extraPawn);
            
            blackPawn.MoveTo(board, Square.At(3, 1));
            extraPawn.MoveTo(board, Square.At(5,6));
            blackPawn.MoveTo(board, Square.At(4, 1));
            var moves = whitePawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(3, 1));
        }
        [Test]
        public void WhitePawns_CanNotTakeEnPassantIfItWasntPreviousMove()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            var extraWhitePawn = new Pawn(Player.White);
            var extraBlackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 0), whitePawn);
            board.AddPiece(Square.At(2, 1), blackPawn);
            board.AddPiece(Square.At(7, 6), extraWhitePawn);
            board.AddPiece(Square.At(2, 6), extraBlackPawn);
            
            blackPawn.MoveTo(board, Square.At(4, 1));
            extraWhitePawn.MoveTo(board, Square.At(5,6));
            extraBlackPawn.MoveTo(board, Square.At(3, 6));
            var moves = whitePawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(3, 1));
        }
        
        [Test]
        public void WhenPerformingEnPassantMove_TakenPieceGetsTaken()
        {
            var board = new Board(Player.Black);
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 0), whitePawn);
            board.AddPiece(Square.At(2, 1), blackPawn);
            
            blackPawn.MoveTo(board, Square.At(4, 1));
            whitePawn.MoveTo(board, Square.At(3, 1));
            
            board.GetPiece(Square.At(4,1)).Should().BeNull();
        }
    }
}