using ChessMoves.PieceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessMoves.Tests
{
    public class PawnTests
    {
        ChessBoard chessBoard = new ChessBoard();

        [Theory]
        [InlineData("C6",3,7)]
        public void OnlyForwardVerticalCellShouldBeReturned(string input,int outputColumn, int outputRow)
        {
            //Arrange
            Initializer.Initialize();
            List<Cell> expectedCells = new List<Cell> { new Cell { row = outputRow, column = outputColumn } };
            Pawn pawn = new Pawn();

            //Act
            pawn.MapUserInputCellToChessPieceInitialRowColumn(input);
            pawn.SearchForAllPossibleMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells,pawn.allPossibleMoves));
        }

        [Theory]
        [InlineData("D8")]
        public void NoMovesShouldBeReturnedIfPawnIsAtTopmostRow(string input)
        {
            //Arrange
            Initializer.Initialize();
            Pawn pawn = new Pawn();

            //Act
            pawn.MapUserInputCellToChessPieceInitialRowColumn(input);
            pawn.SearchForAllPossibleMoves(chessBoard);

            //Assert
            Assert.Empty(pawn.allPossibleMoves);
        }

        private bool AreTwoListsEquivalent(List<Cell> expectedOutputCells, List<Cell> actualOutputCells)
        {
            return (expectedOutputCells.All(actualOutputCells.Contains) && expectedOutputCells.Count == actualOutputCells.Count);
        }
    }
}
