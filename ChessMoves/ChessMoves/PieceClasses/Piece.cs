﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    public abstract class Piece
    {
        public Piece() 
        {
            initialCell = new Cell();
            allPossibleMoves = new List<Cell>();
        }

        internal Cell initialCell;

        internal List<Cell> allPossibleMoves;

        internal abstract void SearchForAllPossibleMoves(ChessBoard chessBoard);

        internal void MapUserInputToChessPiece(string userInput)
        {
            string[] nameAndCell = userInput.Split(' ');
            if (nameAndCell.Length != 2)
            {
                throw new ArgumentException("Invalid Input");
            }

            MapUserInputCellToChessPieceInitialRowColumn(nameAndCell[1]);
        }

        internal void MapUserInputCellToChessPieceInitialRowColumn(string userInputCell)
        {
            if (userInputCell.Length != 2)
                throw new ArgumentException("Invalid Cell number");

            char columnChar = userInputCell[0];
            char rowChar = userInputCell[1];

            if (!Initializer.columnNameToNumberMap.ContainsKey(columnChar.ToString()))
                throw new ArgumentException("Invalid Column Name");

            if (!Initializer.rowNameToNumberMap.ContainsKey(rowChar.ToString()))
                throw new ArgumentException("Invalid Row Number");

            int initialColumn = Initializer.columnNameToNumberMap[columnChar.ToString()];
            int initialRow = Initializer.rowNameToNumberMap[rowChar.ToString()];

            initialCell.column = initialColumn;
            initialCell.row = initialRow;
        }

        internal void AddMoveToPossibleMoves(int row, int column, ChessBoard chessBoard)
        {
            if (row < 1 || row > chessBoard.Rows || column < 1 || column > chessBoard.Columns)
                return;
            if (allPossibleMoves == null)
                allPossibleMoves = new List<Cell>();
            allPossibleMoves.Add(new Cell { row = row, column = column });
        }

        internal void SearchForAllPossibleDiagonalMoves(ChessBoard chessBoard)
        {
            SearchForAllPossibleMovesOnTheNorthEastOfInitialCell(chessBoard);

            SearchForAllPossibleMovesOnTheNorthWestOfInitialCell(chessBoard);

            SearchForAllPossibleMovesOnTheSouthEastOfInitialCell(chessBoard);

            SearchForAllPossibleMovesOnTheSouthWestOfInitialCell(chessBoard);
            /****i = initialCell.row - 1;
            j = initialCell.column - 1;
            //Adding cells on SouthWest side
            while (i > 0 && j > 0)
            {
                AddCell(i, j, chessBoard);
                i--;
                j--;
            }

            i = initialCell.row - 1;
            j = initialCell.column + 1;
            //Adding cells on SouthEast side
            while (i > 0 && j <= chessBoard.Columns)
            {
                AddCell(i, j, chessBoard);
                i--;
                j++;
            }***/
        }

        private void SearchForAllPossibleMovesOnTheSouthWestOfInitialCell(ChessBoard chessBoard)
        {
            int i = initialCell.row - 1;
            int j = initialCell.column - 1;
            //Adding cells on SouthWest side
            while (i > 0 && j > 0)
            {
                AddMoveToPossibleMoves(i, j, chessBoard);
                i--;
                j--;
            }
        }

        private void SearchForAllPossibleMovesOnTheSouthEastOfInitialCell(ChessBoard chessBoard)
        {
            int i = initialCell.row - 1;
            int j = initialCell.column + 1;
            while (i > 0 && j <= chessBoard.Columns)
            {
                AddMoveToPossibleMoves(i, j, chessBoard);
                i--;
                j++;
            }
        }

        private void SearchForAllPossibleMovesOnTheNorthWestOfInitialCell(ChessBoard chessBoard)
        {
            int i = initialCell.row + 1;
            int j = initialCell.column - 1;
            while (i <= chessBoard.Rows && j > 0)
            {
                AddMoveToPossibleMoves(i, j, chessBoard);
                i++;
                j--;
            }
        }

        private void SearchForAllPossibleMovesOnTheNorthEastOfInitialCell(ChessBoard chessBoard)
        {
            int i = initialCell.row + 1;
            int j = initialCell.column + 1;
            while (i <= chessBoard.Rows && j <= chessBoard.Columns)
            {
                AddMoveToPossibleMoves(i, j, chessBoard);
                i++;
                j++;
            }
        }
    }
}
