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
        [InlineData(3,6,3,7)]
        public void OnlyForwardVerticalCellShouldBeReturned(int inputColumn,int inputRow, int outputColumn, int outputRow)
        {
            //Arrange
            Initializer.Initialize();
            List<Cell> expectedCells = new List<Cell> { new Cell { row = outputRow, column = outputColumn } };
            Pawn pawn = new Pawn();
            pawn.initialCell = new Cell { column = inputColumn, row = inputRow };

            //Act
            pawn.SearchForAllPossibleMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells,pawn.allPossibleMoves));
        }

        [Theory]
        [InlineData(8,4)]
        public void NoMovesShouldBeReturnedIfPawnIsAtTopmostRow(int inputRow,int inputColumn)
        {
            //Arrange
            Initializer.Initialize();
            Pawn pawn = new Pawn();
            pawn.initialCell = new Cell { row = inputRow, column = inputColumn };

            //Act
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
