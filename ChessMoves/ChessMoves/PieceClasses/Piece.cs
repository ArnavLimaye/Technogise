using System;
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

        internal void MapUserInputCellToChessPieceInitialCell(string userInputCell)
        {
            char columnChar = userInputCell[0];
            char rowChar = userInputCell[1];

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

        internal void SearchForAllPossibleVerticalMoves(ChessBoard chessBoard)
        {
            int i = 1;
            while (i <= chessBoard.Rows)
            {
                if (initialCell.row != i) //Exclude initial cell
                {
                    AddMoveToPossibleMoves(i, initialCell.column, chessBoard);
                }
                i++;
            }
        }

        internal void SearchForAllPossibleHorizontalMoves(ChessBoard chessBoard)
        {
            int j = 1;
            while (j <= chessBoard.Columns)
            {
                if (initialCell.column != j) //Exclude initial cell
                {
                    AddMoveToPossibleMoves(initialCell.row, j , chessBoard);
                }
                j++;
            }
        }

        internal void SearchForAllPossibleSpecialMoves(ChessBoard chessBoard)
        {
            int initialRow = initialCell.row;
            int initialColumn = initialCell.column;

            AddMoveToPossibleMoves(initialRow + 1, initialColumn + 2, chessBoard);
            AddMoveToPossibleMoves(initialRow + 1, initialColumn - 2, chessBoard);
            AddMoveToPossibleMoves(initialRow - 1, initialColumn + 2, chessBoard);
            AddMoveToPossibleMoves(initialRow - 1, initialColumn - 2, chessBoard);
            AddMoveToPossibleMoves(initialRow + 2, initialColumn + 1, chessBoard);
            AddMoveToPossibleMoves(initialRow - 2, initialColumn + 1, chessBoard);
            AddMoveToPossibleMoves(initialRow + 2, initialColumn - 1, chessBoard);
            AddMoveToPossibleMoves(initialRow - 2, initialColumn - 1, chessBoard);
        }

        internal void SearchForAllPossibleAdjacentMoves(ChessBoard chessBoard)
        {
            int initialRow = initialCell.row;
            int initialColumn = initialCell.column;

            SearchForAllPossibleAdjacentDiagonalMoves(chessBoard,initialRow,initialColumn);
            SearchForAllPossibleAdjacentVerticalMoves(chessBoard,initialRow, initialColumn);
            SearchForAllPossibleAdjacentHorizontalMoves(chessBoard,initialRow, initialColumn);
        }

        private void SearchForAllPossibleAdjacentVerticalMoves(ChessBoard chessBoard, int initialRow, int initialColumn)
        {
            AddMoveToPossibleMoves(initialRow + 1, initialColumn,chessBoard);
            AddMoveToPossibleMoves(initialRow - 1, initialColumn, chessBoard);
        }

        private void SearchForAllPossibleAdjacentHorizontalMoves(ChessBoard chessBoard, int initialRow, int initialColumn)
        {
            AddMoveToPossibleMoves(initialRow, initialColumn + 1, chessBoard);
            AddMoveToPossibleMoves(initialRow, initialColumn - 1, chessBoard);
        }

        private void SearchForAllPossibleAdjacentDiagonalMoves(ChessBoard chessBoard, int initialRow, int initialColumn)
        {
            AddMoveToPossibleMoves(initialRow + 1, initialColumn + 1,chessBoard);
            AddMoveToPossibleMoves(initialRow + 1, initialColumn - 1,chessBoard);
            AddMoveToPossibleMoves(initialRow - 1, initialColumn + 1, chessBoard);
            AddMoveToPossibleMoves(initialRow - 1, initialColumn - 1, chessBoard);
        }
    }
}
