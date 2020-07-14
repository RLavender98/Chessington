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
        public void WhitePawns_CanTakeEnPassant()
        {
            var board = new Board();
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 0), whitePawn);
            board.AddPiece(Square.At(2, 1), blackPawn);
            
            blackPawn.MoveTo(board, Square.At(4, 1));
            var moves = whitePawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 1));
        }
        
        [Test]
        public void BlackPawns_CanTakeEnPassant()
        {
            var board = new Board();
            var whitePawn = new Pawn(Player.White);
            var blackPawn = new Pawn(Player.White);
            board.AddPiece(Square.At(7, 0), whitePawn);
            board.AddPiece(Square.At(5, 1), blackPawn);
            
            whitePawn.MoveTo(board, Square.At(5, 0));
            var moves = blackPawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 1));
        }
    }
}