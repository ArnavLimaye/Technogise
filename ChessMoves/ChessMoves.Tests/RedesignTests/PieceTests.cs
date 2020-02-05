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

        [Fact]
        public void InvalidArgumentExceptionShouldBeThrownIfUserGivesInputWithoutSpace()
        {
            //Arrange

            //Act
            string userInput = "RookB6";
            var piece = new FakePiece();
            
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => piece.MapUserInputToChessPiece(userInput));
            Assert.Equal("Invalid Input", ex.Message);
        }

        [Theory]
        [InlineData("I6", "Invalid Column Name")]
        [InlineData("H9", "Invalid Row Number")]
        [InlineData("6B", "Invalid Column Name")]
        [InlineData("BB", "Invalid Row Number")]
        [InlineData("66", "Invalid Column Name")]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidCell(string cell,string expectedErrorMessage)
        {
            //Arrange

            //Act
            string userInputCell = cell;
            Piece piece = new FakePiece();

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => piece.MapUserInputCellToChessPieceInitialRowColumn(userInputCell));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Theory]
        [InlineData("B6")]
        public void ValidCellShouldSetChessPieceCellRowAndCellColumnPropertiesRightly(string inputCell)
        {
            //Arrange
            int expectedColumn = 2;
            int expectedRow = 6;

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialRowColumn(inputCell);

            //Assert
            Assert.Equal(expectedColumn, piece.initialCell.column);
            Assert.Equal(expectedRow, piece.initialCell.row);
        }

        [Theory]
        [InlineData("Rook B6")]
        public void ValidInputShouldBeMappedToChessPieceRightly(string userInput)
        {
            //Arrange
            int expectedColumn = 2;
            int expectedRow = 6;

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputToChessPiece(userInput);

            //Assert
            Assert.Equal(expectedColumn, piece.initialCell.column);
            Assert.Equal(expectedRow, piece.initialCell.row);
        }

        [Fact]
        public void AllPossibleDiagonalMovesShouldBeReturnedBySearchForAllPossibleDiagonalMovesMethod()
        {
            //Arrange
            string input = "G7";
            var expectedCells = new List<Cell> { new Cell { row = 8,column = 8},new Cell { row = 6,column = 6},
                new Cell { row = 5,column = 5},new Cell { row = 4, column = 4}, new Cell { row = 3, column = 3},
                new Cell { row = 2,column =2},new Cell{ row= 1,column = 1},new Cell{ row = 8,column=6},new Cell{ row = 6,column = 8} };

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialRowColumn(input);
            piece.SearchForAllPossibleDiagonalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells,piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleHorizontalMovesShouldBeReturnedBySearchForAllPossibleHorizontalMovesMethod()
        {
            //Arrange
            string input = "B3";
            var expectedCells = new List<Cell> { new Cell { row = 3,column = 1}, new Cell { row = 3, column = 3 },
                new Cell { row = 3,column = 4},new Cell { row = 3,column = 5},new Cell { row = 3,column = 6},new Cell { row = 3,column = 7}
                ,new Cell { row = 3,column = 8}};

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialRowColumn(input);
            piece.SearchForAllPossibleHorizontalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleVerticalMovesShouldBeReturnedBySearchForAllPossibleVerticalMovesMethod()
        {
            //Arrange
            string input = "H6";
            var expectedCells = new List<Cell> { new Cell { row = 1,column = 8}, new Cell { row = 2, column = 8 },
                new Cell { row = 3,column = 8},new Cell { row = 4,column = 8},new Cell { row = 5,column = 8},new Cell { row = 7,column = 8}
                ,new Cell { row = 8,column = 8}};

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialRowColumn(input);
            piece.SearchForAllPossibleVerticalMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        [Fact]
        public void AllPossibleSpecialMovesShouldBeReturnedBySearchForAllPossibleSpecialMovesMethod()
        {
            //Arrange
            string input = "H7";
            var expectedCells = new List<Cell> { new Cell { row = 8,column = 6}, new Cell { row = 6, column = 6 },
                new Cell { row = 5,column = 7}};

            //Act
            FakePiece piece = new FakePiece();
            piece.MapUserInputCellToChessPieceInitialRowColumn(input);
            piece.SearchForAllPossibleSpecialMoves(chessBoard);

            //Assert
            Assert.True(AreTwoListsEquivalent(expectedCells, piece.allPossibleMoves));
        }

        private bool AreTwoListsEquivalent(List<Cell> expectedOutputCells, List<Cell> actualOutputCells)
        {
            return (expectedOutputCells.All(actualOutputCells.Contains) && expectedOutputCells.Count == actualOutputCells.Count);
        }

    }
}
