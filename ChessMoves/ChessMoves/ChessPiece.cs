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

        public enum MoveTypes { Horizontal = 1, Vertical, Diagonal, Special, SingleCell, MultiCell, OnlyForward }    //Special is for Knight's movement
        
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

        internal void GetAllPossibleMoves()
        {
            if (AllowedMoveTypes.Contains(MoveTypes.Diagonal))
            { 
                GetAllPossibleDiagonalMoves(); 
            }
            
            if (AllowedMoveTypes.Contains(MoveTypes.Vertical))
            { 
                GetAllPossibleVerticalMoves(); 
            }
            
            if (AllowedMoveTypes.Contains(MoveTypes.Horizontal))
            { 
                GetAllPossibleHorizontalMoves(); 
            }
            
            if (AllowedMoveTypes.Contains(MoveTypes.Special))
            {
                GetSpecialMoves();
            }
        }

        internal void GetAllPossibleDiagonalMoves()
        {
            bool isSingleMove = CheckIfPieceIsSingleMovePiece(AllowedMoveTypes);
            if (isSingleMove)
            {
                GetAllAdjacentDiagonalCells();
            }
            else
            {
                int i = initialCell.row + 1;
                int j = initialCell.column + 1;
                //Adding cells on NorthEast side
                while(i<9 && j<9)
                {
                    AddCell(i, j);
                    i++;
                    j++;
                }
                
                i = initialCell.row - 1;
                j = initialCell.column - 1;
                //Adding cells on SouthWest side
                while (i>0 && j>0)
                {
                    AddCell(i, j);
                    i--;
                    j--;
                }

                i = initialCell.row + 1;
                j = initialCell.column - 1;
                //Adding cells on NorthWest side
                while (i < 9 && j > 0)
                {
                    AddCell(i, j);
                    i++;
                    j--;
                }

                i = initialCell.row - 1;
                j = initialCell.column + 1;
                //Adding cells on SouthEast side
                while (i > 0 && j < 9)
                {
                    AddCell(i, j);
                    i--;
                    j++;
                }
            }
        }

        private void GetAllAdjacentDiagonalCells()
        {
            bool isOnlyForward = CheckIfPieceIsForwardOnly(AllowedMoveTypes);
            if(!isOnlyForward)
            {
                AddCell(initialCell.row - 1,initialCell.column + 1);
                AddCell(initialCell.row - 1, initialCell.column - 1);
            }
            AddCell(initialCell.row + 1, initialCell.column + 1);
            AddCell(initialCell.row + 1, initialCell.column - 1);
        }

        private void AddCell(int row, int column)
        {
            if (row < 1 || row > 8 || column < 1 || column > 8)
                return;
            if (allowedCells == null)
                allowedCells = new List<Cell>();
            allowedCells.Add(new Cell { row = row, column = column });
        }

        private bool CheckIfPieceIsForwardOnly(List<MoveTypes> allowedMoveTypes)
        {
            return allowedMoveTypes.Contains(MoveTypes.OnlyForward);
        }

        private bool CheckIfPieceIsSingleMovePiece(List<MoveTypes> allowedMoveTypes)
        {
            return allowedMoveTypes.Contains(MoveTypes.SingleCell);
        }

        internal void GetAllPossibleHorizontalMoves()
        {
            throw new NotImplementedException();
        }

        internal void GetAllPossibleVerticalMoves()
        {
            throw new NotImplementedException();
        }

        internal void GetSpecialMoves()
        {
            throw new NotImplementedException();
        }
    }
}
