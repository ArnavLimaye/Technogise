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
    }
}
