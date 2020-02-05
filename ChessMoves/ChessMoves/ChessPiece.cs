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

        private List<MoveType> _allowedMoveTypes;

        internal Cell initialCell;

        internal List<Cell> allowedCells;

        
        
        public string Name { get { return _name; } set { _name = value; } }

        public List<MoveType> AllowedMoveTypes { get { return _allowedMoveTypes; } set { _allowedMoveTypes = value; } }

        
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

        private void AddCell(int row, int column, ChessBoard chessBoard)
        {
            if (row < 1 || row > chessBoard.Rows || column < 1 || column > chessBoard.Columns)
                return;
            if (allowedCells == null)
                allowedCells = new List<Cell>();
            allowedCells.Add(new Cell { row = row, column = column });
        }

        internal void GetAllPossibleMoves(ChessBoard chessBoard)
        {
            if (AllowedMoveTypes.Contains(MoveType.Diagonal))
            { 
                GetAllPossibleDiagonalMoves(chessBoard); 
            }
            
            if (AllowedMoveTypes.Contains(MoveType.Vertical))
            { 
                GetAllPossibleVerticalMoves(chessBoard); 
            }
            
            if (AllowedMoveTypes.Contains(MoveType.Horizontal))
            { 
                GetAllPossibleHorizontalMoves(chessBoard); 
            }
            
            if (AllowedMoveTypes.Contains(MoveType.Special))
            {
                GetSpecialMoves(chessBoard);
            }
        }

        internal void GetAllPossibleDiagonalMoves(ChessBoard chessBoard)
        {
            bool isSingleMove = CheckIfPieceIsSingleMovePiece(AllowedMoveTypes);
            if (isSingleMove)
            {
                GetAllAdjacentDiagonalCells(chessBoard);
            }
            else
            {
                int i = initialCell.row + 1;
                int j = initialCell.column + 1;
                //Adding cells on NorthEast side
                while(i <= chessBoard.Rows && j <= chessBoard.Columns)
                {
                    AddCell(i, j,chessBoard);
                    i++;
                    j++;
                }
                
                i = initialCell.row - 1;
                j = initialCell.column - 1;
                //Adding cells on SouthWest side
                while (i>0 && j>0)
                {
                    AddCell(i, j,chessBoard);
                    i--;
                    j--;
                }

                i = initialCell.row + 1;
                j = initialCell.column - 1;
                //Adding cells on NorthWest side
                while (i <= chessBoard.Rows && j > 0)
                {
                    AddCell(i, j,chessBoard);
                    i++;
                    j--;
                }

                i = initialCell.row - 1;
                j = initialCell.column + 1;
                //Adding cells on SouthEast side
                while (i > 0 && j <= chessBoard.Columns)
                {
                    AddCell(i, j,chessBoard);
                    i--;
                    j++;
                }
            }
        }

        private void GetAllAdjacentDiagonalCells(ChessBoard chessBoard)
        {
            bool isOnlyForward = CheckIfPieceIsForwardOnly(AllowedMoveTypes);
            if(!isOnlyForward)
            {
                AddCell(initialCell.row - 1,initialCell.column + 1,chessBoard);
                AddCell(initialCell.row - 1, initialCell.column - 1,chessBoard);
            }
            AddCell(initialCell.row + 1, initialCell.column + 1,chessBoard);
            AddCell(initialCell.row + 1, initialCell.column - 1,chessBoard);
        }

        

        private bool CheckIfPieceIsForwardOnly(List<MoveType> allowedMoveTypes)
        {
            return allowedMoveTypes.Contains(MoveType.OnlyForward);
        }

        private bool CheckIfPieceIsSingleMovePiece(List<MoveType> allowedMoveTypes)
        {
            return allowedMoveTypes.Contains(MoveType.SingleCell);
        }

        internal void GetAllPossibleHorizontalMoves(ChessBoard chessBoard)
        {
            bool isSingleMove = CheckIfPieceIsSingleMovePiece(AllowedMoveTypes);
            if (isSingleMove)
            {
                GetAllAdjacentHorizontalCells(chessBoard);
            }
            else
            {
                int j = 1;
                while(j <= chessBoard.Columns)
                {
                    if(j != initialCell.column)
                    {
                        AddCell(initialCell.row, j,chessBoard);
                    }
                    j++;
                }
            }
        }

        private void GetAllAdjacentHorizontalCells(ChessBoard chessBoard)
        {
            AddCell(initialCell.row, initialCell.column + 1,chessBoard);
            AddCell(initialCell.row, initialCell.column - 1,chessBoard);
        }

        internal void GetAllPossibleVerticalMoves(ChessBoard chessBoard)
        {
            bool isSingleMove = CheckIfPieceIsSingleMovePiece(AllowedMoveTypes);
            if(isSingleMove)
            {
                GetAllAdjacentVerticalCells(AllowedMoveTypes,chessBoard);
            }
            else
            {
                int i = 1;
                while (i <= chessBoard.Rows)
                {
                    if(initialCell.row != i) //Exclude initial cell
                    {
                        AddCell(i, initialCell.column,chessBoard);
                    }
                    i++;
                }
            }
        }

        private void GetAllAdjacentVerticalCells(List<MoveType> allowedMoveTypes,ChessBoard chessBoard)
        {
            bool isForwardOnly = CheckIfPieceIsForwardOnly(allowedMoveTypes);

            if(!isForwardOnly)
            {
                AddCell(initialCell.row - 1, initialCell.column,chessBoard);
            }
            AddCell(initialCell.row + 1, initialCell.column,chessBoard);
        }

        internal void GetSpecialMoves(ChessBoard chessBoard)
        {
            int initialRow = initialCell.row;
            int initialColumn = initialCell.column;

            AddCell(initialRow + 1, initialColumn + 2,chessBoard);
            AddCell(initialRow + 1, initialColumn - 2,chessBoard);
            AddCell(initialRow - 1, initialColumn + 2,chessBoard);
            AddCell(initialRow - 1, initialColumn - 2,chessBoard);
            AddCell(initialRow + 2, initialColumn + 1,chessBoard);
            AddCell(initialRow - 2, initialColumn + 1,chessBoard);
            AddCell(initialRow + 2, initialColumn - 1,chessBoard);
            AddCell(initialRow - 2, initialColumn - 1,chessBoard);
        }
    }
}
