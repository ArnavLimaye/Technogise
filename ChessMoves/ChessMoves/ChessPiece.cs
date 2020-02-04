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

        private int _initialCellRow;

        private int _initialCellColumn;

        private List<int> _allowedRows;

        private List<int> _allowedColumns;

        public enum MoveTypes { Horizontal = 1, Vertical, Diagonal, Special, SingleCell, MultiCell }    //Special is for Knight's movement
        
        public string Name { get { return _name; } set { _name = value; } }

        public List<MoveTypes> AllowedMoveTypes { get { return _allowedMoveTypes; } set { _allowedMoveTypes = value; } }

        public int InitialCellRow { get { return _initialCellRow; } set { _initialCellRow = value; } }

        public int InitialCellColumn { get { return _initialCellColumn; } set {_initialCellColumn = value; } }

        public List<int> AllowedRows { get { return _allowedRows; } set { _allowedRows = value; } }

        public List<int> AllowedColumns { get { return _allowedColumns; } set { _allowedColumns = value; } }
    }
}
