using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChessMoves.Tests
{
    public class PieceTests
    {
        ChessBoard chessBoard = new ChessBoard();

        [Theory]
        [InlineData("B6")]
        public void ValidCellShouldSetChessPieceCellRowAndCellColumnPropertiesRightly(string inputCell)
        {
            //Arrange
            int expectedColumn = 2;
            int expectedRow = 6;

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialCell(inputCell);

            //Assert
            Assert.Equal(expectedColumn, piece.initialCell.column);
            Assert.Equal(expectedRow, piece.initialCell.row);
        }


        [Fact]
        public void AllPossibleDiagonalMovesShouldBeReturnedBySearchForAllPossibleDiagonalMovesMethod()
        {
            //Arrange
            int inputRow = 7;
            int inputColumn = 7;
            var expectedCells = new List<Cell> { new Cell { row = 8,column = 8},new Cell { row = 6,column = 6},
                new Cell { row = 5,column = 5},new Cell { row = 4, column = 4}, new Cell { row = 3, column = 3},
                new Cell { row = 2,column =2},new Cell{ row= 1,column = 1},new Cell{ row = 8,column=6},new Cell{ row = 6,column = 8} };

            //Act
            FakePiece piece = new FakePiece();
            piece.initialCell = new Cell { row = inputRow, column = inputColumn };
            piece.SearchForAllPossibleDiagonalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells,piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleHorizontalMovesShouldBeReturnedBySearchForAllPossibleHorizontalMovesMethod()
        {
            //Arrange
            int inputRow = 3;
            int inputColumn = 2;
            var expectedCells = new List<Cell> { new Cell { row = 3,column = 1}, new Cell { row = 3, column = 3 },
                new Cell { row = 3,column = 4},new Cell { row = 3,column = 5},new Cell { row = 3,column = 6},new Cell { row = 3,column = 7}
                ,new Cell { row = 3,column = 8}};

            //Act
            FakePiece piece = new FakePiece();
            piece.initialCell = new Cell { column = inputColumn, row = inputRow };
            piece.SearchForAllPossibleHorizontalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleVerticalMovesShouldBeReturnedBySearchForAllPossibleVerticalMovesMethod()
        {
            //Arrange
            int inputRow = 6;
            int inputColumn = 8;
            var expectedCells = new List<Cell> { new Cell { row = 1,column = 8}, new Cell { row = 2, column = 8 },
                new Cell { row = 3,column = 8},new Cell { row = 4,column = 8},new Cell { row = 5,column = 8},new Cell { row = 7,column = 8}
                ,new Cell { row = 8,column = 8}};

            //Act
            FakePiece piece = new FakePiece();
            piece.initialCell = new Cell { row = inputRow, column = inputColumn };
            piece.SearchForAllPossibleVerticalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleSpecialMovesShouldBeReturnedBySearchForAllPossibleSpecialMovesMethod()
        {
            //Arrange
            int inputRow = 7;
            int inputColumn = 8;
            var expectedCells = new List<Cell> { new Cell { row = 8,column = 6}, new Cell { row = 6, column = 6 },
                new Cell { row = 5,column = 7}};

            //Act
            FakePiece piece = new FakePiece();
            piece.initialCell = new Cell { row = inputRow, column = inputColumn };
            piece.SearchForAllPossibleSpecialMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleAdjacentMovesShouldBeReturnedBySearchForAllPossibleAdjacentMovesMethod()
        {
            //Arrange
            int inputRow = 3;
            int inputColumn = 4;
            var expectedCells = new List<Cell> { new Cell { row = 3,column = 3}, new Cell { row = 3, column = 5 },
                new Cell { row = 2,column = 3},new Cell { row = 2,column = 4},new Cell { row = 2,column = 5},
                new Cell { row = 4,column = 3},new Cell { row = 4,column = 4},new Cell { row = 4,column = 5}};

            //Act
            FakePiece piece = new FakePiece();
            piece.initialCell = new Cell { column = inputColumn, row = inputRow };
            piece.SearchForAllPossibleAdjacentMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        private bool AreTwoListsEquivalent(List<Cell> expectedOutputCells, List<Cell> actualOutputCells)
        {
            return (expectedOutputCells.All(actualOutputCells.Contains) && expectedOutputCells.Count == actualOutputCells.Count);
        }

    }
}
