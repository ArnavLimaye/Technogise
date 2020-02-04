using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static ChessMoves.ChessBoard;

[assembly: InternalsVisibleTo("ChessMoves.Tests")]
namespace ChessMoves
{
    internal class ChessPiece
    {
        private string _name;

        private List<MoveTypes> _allowedMoveTypes;

        internal Cell initialCell;

        internal List<Cell> allowedCells;

        public enum MoveTypes { Horizontal = 1, Vertical, Diagonal, Special, SingleCell, MultiCell }    //Special is for Knight's movement
        
        public string Name { get { return _name; } set { _name = value; } }

        public List<MoveTypes> AllowedMoveTypes { get { return _allowedMoveTypes; } set { _allowedMoveTypes = value; } }

        
        internal void MapUserInputToChessPiece(string userInput)
        {
            string[] nameAndCell = userInput.Split(' ');
            if(nameAndCell.Length != 2)
            {
                throw new ArgumentException("Invalid Input");
            }
            
            MapUserInputNameToChessPieceNameAndPieceMoveType(nameAndCell[0]);
            
            MapUserInputCellToChessPieceInitialRowColumn(nameAndCell[1]);
        }

        internal void MapUserInputNameToChessPieceNameAndPieceMoveType(string userInputName)
        {
            if (!Initializer.pieceNameToPieceMoveMap.ContainsKey(userInputName))
                throw new ArgumentException("Piece Name is not known");
            else
            {
                Name = userInputName;
                AllowedMoveTypes = Initializer.pieceNameToPieceMoveMap[userInputName];
            }
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
                throw new ArgumentException("Invalid row number");

            int initialColumn = Initializer.columnNameToNumberMap[columnChar.ToString()];
            int initialRow = Initializer.rowNameToNumberMap[rowChar.ToString()];
            
            initialCell.column = initialColumn;
            initialCell.row = initialRow;
            
        }

        internal List<Cell> GetAllPossibleMoves()
        {

            throw new NotImplementedException();
        }
    }
}
