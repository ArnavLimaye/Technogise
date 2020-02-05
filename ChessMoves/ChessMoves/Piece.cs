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
        internal Cell initialCell;

        internal List<Cell> allPossibleMoves;

        internal abstract void SearchForAllPossibleMoves(ChessBoard chessboard);

        internal void AddCell(int row, int column, ChessBoard chessBoard)
        {
            if (row < 1 || row > chessBoard.Rows || column < 1 || column > chessBoard.Columns)
                return;
            if (allPossibleMoves == null)
                allPossibleMoves = new List<Cell>();
            allPossibleMoves.Add(new Cell { row = row, column = column });
        }

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
    }
}
