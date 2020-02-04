﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static ChessMoves.ChessBoard;
using static ChessMoves.ChessPiece;

namespace ChessMoves.Tests
{
    public class ChessPieceTests
    {
        [Fact]
        public void ChessPiecePropertiesShouldGetAndSetProperly()
        {
            //Arrange
            string expectedName = "Rook";
            List<int> expectedAllowedColumns = new List<int>(){ 2, 3 };
            List<int> expectedAllowedRows = new List<int>() { 1, 2 };
            List<MoveTypes> expectedAllowedMoveTypes = new List<MoveTypes>() { MoveTypes.Horizontal };
            int expectedInitialRow = 3;
            int expectedInitialColumn = 4;
            //Act
            ChessPiece piece = new ChessPiece();
            piece.Name = "Rook";
            piece.AllowedColumns = new List<int>() { 2, 3 };
            piece.AllowedRows = new List<int>() { 1, 2 };
            piece.AllowedMoveTypes = new List<MoveTypes>() { MoveTypes.Horizontal };
            piece.InitialCellRow = 3;
            piece.InitialCellColumn = 4;

            //Assert
            Assert.Equal(expectedName, piece.Name);
            Assert.Equal(expectedAllowedColumns, piece.AllowedColumns);
            Assert.Equal(expectedAllowedRows, piece.AllowedRows);
            Assert.Equal(expectedAllowedMoveTypes, piece.AllowedMoveTypes);
            Assert.Equal(expectedInitialColumn, piece.InitialCellColumn);
            Assert.Equal(expectedInitialRow, piece.InitialCellRow);
        }
    }
}