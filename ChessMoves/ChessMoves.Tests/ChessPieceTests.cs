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

        [Fact]
        public void AllPossibleMovesShouldBeReturnedAfterGivingInitialCellAndChessPiece()
        {
            //Arrnage
            var userInput = "King C4";
            var expectedCells = new List<Cell>() { new Cell { row = 4,column = 5}, new Cell { row = 4, column = 4 },
            new Cell { row = 4,column = 3},new Cell { row = 3,column = 5},new Cell { row = 3,column = 6},new Cell { row = 2,column = 3}
            ,new Cell { row = 2,column = 4},new Cell { row = 2,column = 5}};

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(userInput);
            piece.GetAllPossibleMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;

            Assert.True(cellsAreEquivalent);
        }


        [Fact]
        public void OnlyAdjacentMovesShouldBeReturnedIfPawnOrKingIsGiven()
        {
            //Arrange
            string userInput = "Pawn C6";
            var expectedCells = new List<Cell> { new Cell { row = 6, column = 3 } };

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(userInput);
            piece.GetAllPossibleMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;
            Assert.True(cellsAreEquivalent);
        }

        [Fact]
        public void NoMovesShouldBeReturnedIfPawnIsAtTopmostRow()
        {
            //Arrange
            string userInput = "Pawn D8";

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(userInput);
            piece.GetAllPossibleMoves();

            //Assert
            Assert.True(piece.allowedCells.Count == 0);
        }

        [Fact]
        public void AllDiagonalPossibleMovesShouldBeReturnedByGetDiagonalMovesMethod()
        {
            //Arrange
            string input = "Bishop G7";
            var expectedCells = new List<Cell> { new Cell { row = 8,column = 8},new Cell { row = 6,column = 6},
                new Cell { row = 5,column = 5},new Cell { row = 4, column = 4}, new Cell { row = 3, column = 3},
                new Cell { row = 2,column =2},new Cell{ row= 1,column = 1},new Cell{ row = 8,column=6},new Cell{ row = 6,column = 8} };

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(input);
            piece.GetDiagonalMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;

            Assert.True(cellsAreEquivalent);
        }

        [Fact]
        public void AllPossibleHorizontalMovesShouldBeReturnedByGetHorizontalMovesMethod()
        {
            //Arrange
            string input = "Rook G7";
            var expectedCells = new List<Cell> { new Cell { row = 7,column = 1}, new Cell { row = 7, column = 2 },
                new Cell { row = 7,column = 3}, new Cell { row = 7,column = 4},new Cell { row = 7,column = 5},new Cell { row = 7,column = 6},
                new Cell { row = 7,column = 8}};

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(input);
            piece.GetHorizontalMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;
            Assert.True(cellsAreEquivalent);
        }

        [Fact]
        public void AllPossibleVerticalMovesShouldBeReturnedByGetVerticalMovesMethod()
        {
            //Arrange
            string input = "Rook G7";
            var expectedCells = new List<Cell> { new Cell { row = 1,column = 7}, new Cell { row = 2, column = 7 },
                new Cell { row = 3,column = 7},new Cell { row = 4,column = 7},new Cell { row = 5,column = 7},new Cell { row = 6,column = 7}
                ,new Cell { row = 8,column = 7}};

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(input);
            piece.GetVerticalMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;
            Assert.True(cellsAreEquivalent);
        }

        [Fact]
        public void AllPossibleSpecialMovesShouldBeReturnedByGetSpecialMovesMethod()
        {
            //Arrange
            string input = "Knight G7";
            var expectedCells = new List<Cell> { new Cell { row = 5,column = 8}, new Cell { row = 5, column = 6 },
                new Cell { row = 8,column = 5},new Cell { row = 6,column = 5}};

            //Act
            ChessPiece piece = new ChessPiece();
            piece.MapUserInputToChessPiece(input);
            piece.GetSpecialMoves();

            //Assert
            var cellsAreEquivalent = expectedCells.All(piece.allowedCells.Contains) && expectedCells.Count == piece.allowedCells.Count;
            Assert.True(cellsAreEquivalent);
        }
    }
}
