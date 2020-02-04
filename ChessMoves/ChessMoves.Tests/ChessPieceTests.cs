using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using static ChessMoves.ChessPiece;

namespace ChessMoves.Tests
{
    public class ChessPieceTests
    {
        //Writing a constructor to call initialize method of Initializer
        public ChessPieceTests()
        {
            Initializer.Initialize();
        }

        [Fact]
        public void ChessPiecePropertiesShouldGetAndSetProperly()
        {
            //Arrange
            string expectedName = "Rook";
            List<Cell> expectedAllowedCells = new List<Cell> { new Cell() { row = 1, column = 2 }, new Cell() { row = 2, column = 3 } };
            List<MoveTypes> expectedAllowedMoveTypes = new List<MoveTypes>() { MoveTypes.Horizontal };
            Cell expectedInitialCell = new Cell() { row = 3, column = 4};
            var expectedAllowedCellsStr = JsonConvert.SerializeObject(expectedAllowedCells);
            var expectedInitialCellStr = JsonConvert.SerializeObject(expectedInitialCell);

            //Act
            ChessPiece piece = new ChessPiece();
            piece.Name = "Rook";
            piece.allowedCells = new List<Cell> { new Cell() { row = 1, column = 2 }, new Cell() { row = 2, column = 3 } }; ;
            piece.AllowedMoveTypes = new List<MoveTypes>() { MoveTypes.Horizontal };
            piece.initialCell = new Cell() { row = 3, column = 4 };
            var allowedCellsStr = JsonConvert.SerializeObject(piece.allowedCells);
            var initialCellStr = JsonConvert.SerializeObject(piece.initialCell);

            //Assert
            Assert.Equal(expectedName, piece.Name);
            Assert.Equal(expectedAllowedCellsStr, allowedCellsStr);
            Assert.Equal(expectedAllowedMoveTypes, piece.AllowedMoveTypes);
            Assert.Equal(expectedInitialCellStr, initialCellStr);
        }

        [Fact]
        public void InvalidArgumentExceptionShouldBeThrownIfUserGivesInputWithoutSpace()
        {
            //Arrange

            //Act
            string userInput = "RookB6";
            ChessPiece piece = new ChessPiece();


            //Assert
            Assert.Throws< ArgumentException>(() => piece.MapUserInputToChessPiece(userInput));
        }

        [Fact]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidName()
        {
            //Arrange

            //Act
            string userInputName = "Camel";
            ChessPiece piece = new ChessPiece();


            //Assert
            Assert.Throws<ArgumentException>(() => piece.MapUserInputNameToChessPieceNameAndPieceMoveType(userInputName));
        }

        [Theory]
        [InlineData("I6")]
        [InlineData("H9")]
        [InlineData("6B")]
        [InlineData("BB")]
        [InlineData("66")]
        public void InvalidArgumentExceptionShouldBeThrownIfUserInputsInvalidCell(string cell)
        {
            //Arrange

            //Act
            string userInputCell = cell;
            ChessPiece piece = new ChessPiece();

            //Assert
            Assert.Throws<ArgumentException>(() => piece.MapUserInputCellToChessPieceInitialRowColumn(userInputCell));
        }

        [Theory]
        [InlineData("Bishop")]
        public void ValidPieceNameShouldSetChessPieceNameAndAllowedMoveTypesRightly(string pieceName)
        {
            //Arrange
            string expected = pieceName;
            List<MoveTypes> expectedMoveTypes = Initializer.pieceNameToPieceMoveMap[pieceName];

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputNameToChessPieceNameAndPieceMoveType(pieceName);

            //Assert
            Assert.Equal(expected, piece.Name);
            Assert.Equal(expectedMoveTypes, piece.AllowedMoveTypes);
        }

        [Theory]
        [InlineData("B6")]
        public void ValidCellShouldSetChessPieceCellRowAndCellColumnPropertiesRightly(string inputCell)
        {
            //Arrange
            int expectedColumn = 2;
            int expectedRow = 6;

            //Act
            ChessPiece piece = new ChessPiece();
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
            string expectedName = "Rook";
            int expectedColumn = 2;
            int expectedRow = 6;

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(userInput);

            //Assert
            Assert.Equal(expectedName, piece.Name);
            Assert.Equal(expectedColumn, piece.initialCell.column);
            Assert.Equal(expectedRow, piece.initialCell.row);
        }

        [Theory]
        [InlineData("King C4")]
        public void AllPossibleMovesShouldBeReturnedAfterGivingInitialCellAndChessPiece(string userInput)
        {
            //Arrnage
            var expectedCells = new List<Cell>() { new Cell { row = 4,column = 5}, new Cell { row = 4, column = 4 },
            new Cell { row = 4,column = 3},new Cell { row = 3,column = 5},new Cell { row = 3,column = 6},new Cell { row = 2,column = 3}
            ,new Cell { row = 2,column = 4},new Cell { row = 2,column = 5}};

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(userInput);
            List<Cell> actualCells = piece.GetAllPossibleMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(actualCells.Contains) && expectedCells.Count == actualCells.Count;

            Assert.True(cellsAreEquivalent);
        }
    }
}
