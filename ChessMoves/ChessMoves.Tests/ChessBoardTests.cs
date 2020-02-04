using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ChessMoves;
using Xunit;

namespace ChessMoves.Tests
{
    public class ChessBoardTests
    {
        [Fact]
        public void ChessBoardShouldBeInitializedByDefaultValuesOfRowsAndColumnsIfNoInputIsGiven()
        {
            //Arrange
            int expectedRows = 8;
            int expectedColumns = 8;

            //Act
            ChessBoard chessBoard = new ChessBoard();

            //Assert
            Assert.Equal(chessBoard.Rows, expectedRows);
            Assert.Equal(chessBoard.Columns, expectedColumns);
        }

        [Fact]
        public void RowsAndColumnsPropertiesShouldGetAndSetProperly()
        {
            //Arrange
            int expectedRows = 5;
            int expectedColumns = 7;

            //Act
            ChessBoard chessBoard = new ChessBoard();
            chessBoard.Rows = 5;
            chessBoard.Columns = 7;

            //Assert
            Assert.Equal(chessBoard.Rows, expectedRows);
            Assert.Equal(chessBoard.Columns, expectedColumns);
        }
    }
}
